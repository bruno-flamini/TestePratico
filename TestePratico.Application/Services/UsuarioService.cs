using AutoMapper;
using TestePratico.Application.Interfaces;
using TestePratico.Application.ViewModels;
using TestePratico.Domain.Entities;
using TestePratico.Domain.Interfaces;

namespace TestePratico.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        IUsuarioRepository _usuarioRepository;
        IMapper _mapper;

        public UsuarioService(IMapper mapper, IUsuarioRepository usuarioRepository) 
        {
            _usuarioRepository = usuarioRepository;  
            _mapper = mapper;
        }

        public async Task Inserir(UsuarioViewModel usuarioViewModel)
        {
            var usuarioCriptografado = _mapper.Map<Usuario>(usuarioViewModel);
            usuarioCriptografado.CriptografarSenha();

            await _usuarioRepository.Inserir(usuarioCriptografado);
        }

        public async Task Atualizar(UsuarioViewModel usuarioViewModel)
        {
            var usuario = _mapper.Map<Usuario>(usuarioViewModel);
            await _usuarioRepository.Atualizar(usuario);
        }

        public async Task<UsuarioViewModel> Buscar(int id)
        {
            var usuario = await _usuarioRepository.Buscar(id);

            if (usuario is null)
            {
                throw new ApplicationException("Entidade não foi encontrada!");
            }

            return _mapper.Map<UsuarioViewModel>(usuario);
        }

        public async Task<UsuarioViewModel> Login(UsuarioViewModel usuarioViewModel)
        {
            var usuarioCriptografado = _mapper.Map<Usuario>(usuarioViewModel);
            usuarioCriptografado.CriptografarSenha();

            var usuario = await _usuarioRepository.Login(usuarioCriptografado);

            if (usuario is null)
            {
                return new UsuarioViewModel();
            }

            return _mapper.Map<UsuarioViewModel>(usuario);
        }
    }
}
