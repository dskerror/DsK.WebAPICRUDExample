using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MediatR;
using DsK.Shared.Wrappers;
using System.Threading;
using System.Threading.Tasks;
using DsK.Application.Interfaces.Repositories;
using DsK.Domain.Entities;

namespace DsK.Application.Features.Brands.Commands.AddEdit
{
    public partial class AddEditBrandCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }

    internal class AddEditBrandCommandHandler : IRequestHandler<AddEditBrandCommand, Result<int>>
    {
        private readonly IMapper _mapper;        
        private readonly IUnitOfWork<int> _unitOfWork;

        public AddEditBrandCommandHandler(IUnitOfWork<int> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(AddEditBrandCommand command, CancellationToken cancellationToken)
        {
            if (command.Id == 0)
            {
                var brand = _mapper.Map<Brand>(command);
                brand.CreatedBy = "DsK";
                brand.LastModifiedBy = "DsK";
                await _unitOfWork.Repository<Brand>().AddAsync(brand);
                await _unitOfWork.CommitAndRemoveCache(cancellationToken, "");  //ApplicationConstants.Cache.GetAllBrandsCacheKey
                return await Result<int>.SuccessAsync(brand.Id, "Brand Saved");
            }
            else
            {
                var brand = await _unitOfWork.Repository<Brand>().GetByIdAsync(command.Id);
                if (brand != null)
                {
                    brand.Name = command.Name ?? brand.Name;                    
                    brand.Description = command.Description ?? brand.Description;
                    await _unitOfWork.Repository<Brand>().UpdateAsync(brand);
                    await _unitOfWork.CommitAndRemoveCache(cancellationToken, ""); //ApplicationConstants.Cache.GetAllBrandsCacheKey
                    return await Result<int>.SuccessAsync(brand.Id, "Brand Updated");
                }
                else
                {
                    return await Result<int>.FailAsync("Brand Not Found!");
                }
            }
        }
    }
}