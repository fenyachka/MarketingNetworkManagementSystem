using Application.Core;
using Application.Distributors.DTO;
using Domain.Entities.Distributors;
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
    public class AddPhoto
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
            public DistributorPhotoDto PhotoDto { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IPhotoService _photoService;

            public Handler(IUnitOfWork unitOfWork, IPhotoService photoService)
            {
                _unitOfWork = unitOfWork;
                _photoService = photoService;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var distributor = _unitOfWork.Distributor.Table.SingleOrDefault(x => x.Id == request.Id);

                if (distributor == null) return null;

                if (request.PhotoDto.Photo.Length > 0)
                {
                    var photo = await _photoService.SaveToDiskAsync(request.PhotoDto.Photo);

                    if (photo != null)
                    {
                        distributor.Photo=new Photo
                        {
                            FileName = photo.FileName,
                            PictureUrl = photo.PictureUrl
                        };

                        _unitOfWork.Distributor.Update(distributor);

                        var result = await _unitOfWork.SaveAsync(cancellationToken) > 0;

                        return result ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Failed to add distributor's photo");
                    }
                    else
                    {
                        return Result<Unit>.Failure("Problem saving photo to disk");
                    }
                }
                else
                    return Result<Unit>.Failure("Problem saving photo to disk");
            }
        }
    }
}
