using Sorteo.Domain.Interfaces;
using Sorteo.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Sorteo.Application.Services
{
    /// <summary>
    /// Servicio para la gestión de asignaciones de números de sorteo.
    /// </summary>
    public class AsignacionService
    {
        private readonly IAsignacionRepository _asignacionRepository;
        private readonly Random _random;

        /// <summary>
        /// Constructor de la clase <see cref="AsignacionService"/>.
        /// </summary>
        /// <param name="asignacionRepository">Repositorio de asignaciones.</param>
        public AsignacionService(IAsignacionRepository asignacionRepository)
        {
            _asignacionRepository = asignacionRepository ?? throw new ArgumentNullException(nameof(asignacionRepository));
            _random = new Random();
        }

        /// <summary>
        /// Asigna un número de sorteo a un cliente y usuario específico.
        /// </summary>
        /// <param name="asignacionDto">Datos de la asignación.</param>
        /// <returns>La asignación generada.</returns>
        /// <exception cref="ArgumentException">Se produce cuando se intenta asignar un número inválido.</exception>
        public async Task<Asignacion> AsignarNumeroAsync(Asignacion asignacionDto)
        {
            // Generar un número aleatorio único que cumpla con las restricciones
            string numeroAsignado;
            do
            {
                numeroAsignado = GenerarNumeroAleatorio();
            }
            while (!ValidarNumero(numeroAsignado) || await _asignacionRepository.IsValidAsignacion(Convert.ToInt32(numeroAsignado), asignacionDto.ClienteId, asignacionDto.UsuarioId, asignacionDto.ProductoId));

            // Crear la asignación y persistirla en la base de datos
            var asignacion = new Asignacion
            {
                Numero = Convert.ToInt32(numeroAsignado),
                ClienteId = asignacionDto.ClienteId,
                UsuarioId = asignacionDto.UsuarioId,
                ProductoId = asignacionDto.ProductoId
            };
            await _asignacionRepository.CreateAsync(asignacion);

            return asignacion;
        }

        private string GenerarNumeroAleatorio()
        {
            return _random.Next(10000, 99999).ToString(); // Generar un número aleatorio de 5 dígitos
        }

        private bool ValidarNumero(string numero)
        {
            // Validar que el número tenga 5 dígitos y no tenga más de 3 dígitos consecutivos iguales
            if (numero.Length != 5)
                return false;

            for (int i = 0; i < numero.Length - 2; i++)
            {
                if (numero[i] == numero[i + 1] && numero[i] == numero[i + 2])
                    return false;
            }

            return true;
        }
    }
}
