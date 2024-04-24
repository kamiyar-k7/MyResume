
using Application.ViewModel;

namespace Application.Services.Intefaces;

public interface IHomeService
{
    Task<MainViewModel> HomeIndex(CancellationToken cancellationToken);
}
