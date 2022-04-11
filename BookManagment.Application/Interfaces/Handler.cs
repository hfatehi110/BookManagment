using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagment.Application.Interfaces
{
    public  interface IRequestHandler<TRequest,TResponse> 
    {
        Task<TResponse> Handler(TRequest request, CancellationToken cancellationToken);
    }
     public  interface IRequestHandler<TResponse> 
    {
        List<TResponse> Handler( CancellationToken cancellationToken);
    }

}
