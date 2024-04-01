using Sorteo.Domain.Interfaces;
using Sorteo.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sorteo.Application.Services
{
    /// <summary>
    /// Servicio para la gestión de clientes.
    /// </summary>
    public class ClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        /// <summary>
        /// Constructor de la clase <see cref="ClienteService"/>.
        /// </summary>
        /// <param name="clienteRepository">Repositorio de clientes.</param>
        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        /// <summary>
        /// Obtiene una lista de todos los clientes.
        /// </summary>
        /// <returns>Una lista de objetos Cliente.</returns>
        public async Task<List<Cliente>> ObtenerClientesAsync()
        {
            return await _clienteRepository.GetClientesAsync();
        }
    }
}
