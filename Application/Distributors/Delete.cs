using Application.Core;
using AutoMapper;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Distributors
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public Handler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var distributor = _unitOfWork.Distributor
                    .Include(x => x.DocumentInfo, y => y.AddressInfo, z => z.ContactInfo)
                    .Where(x => x.Id == request.Id)
                    .FirstOrDefault();

                distributor.DateDeleted = DateTime.Now;

                _unitOfWork.Distributor.Update(distributor);

                //აქ წესით უნდა იყოს ლოგიკა რა უნდა მოუვიდეს რეფერალებს და მათ დონეებს
                //ან ყველაფერი რჩება როგორც არის და ლიმიტები რჩება იგივე

                var result = await _unitOfWork.SaveAsync(cancellationToken) > 0;

                if (!result) return Result<Unit>.Failure("Failed to delete distributor");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
