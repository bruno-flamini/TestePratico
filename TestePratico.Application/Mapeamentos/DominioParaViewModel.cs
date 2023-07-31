using AutoMapper;
using TestePratico.Application.ViewModels;
using TestePratico.Domain.Entities;

namespace TestePratico.Application.Mapeamentos
{
    public class DominioParaViewModel : Profile
    {
        protected internal DominioParaViewModel()
        {
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
            CreateMap<Venda, VendaViewModel>().ReverseMap();
            CreateMap<ItemVenda, ItemVendaViewModel>().ReverseMap();
        }
    }
}
