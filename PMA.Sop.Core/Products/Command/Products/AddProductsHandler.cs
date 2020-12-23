using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PMA.Sop.Domain.Product.Commands.Brands;
using PMA.Sop.Domain.Product.Commands.Products;
using PMA.Sop.Domain.Product.Entities;
using PMA.Sop.Domain.Product.Repositories.Categories;
using PMA.Sop.Domain.Product.Repositories.Products;
using PMA.Sop.Domain.SeedWork;
using PMA.Sop.Framework.Dtos;
using PMA.Sop.Framework.Resources.Interface;
using PMA.Sop.Resources.Resources;

namespace PMA.Sop.ApplicationServices.Products.Command.Products
{
    public class AddProductsHandler : IRequestHandler<ProductsCreateCommand, ResultDto>
    {
        private readonly IProductsRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IResourceManager _resourceManager;
        private readonly ResultDto _result;

        public AddProductsHandler(IProductsRepository repository, IUnitOfWork unitOfWork, IMapper mapper, IResourceManager resourceManager)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _resourceManager = resourceManager;
            _result = new ResultDto(_resourceManager);
            
        }

        public async Task<ResultDto> Handle(ProductsCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request != null)
                {
                    if (IsValid(request))
                    {

                        var mapper = new Product()
                        {
                            CreateDate = request.CreateDate,
                            CreatorUserId = request.CreatorUserId,

                            Description = request.Description,
                            Title = request.Title,
                            BrandId = request.BrandId,
                            CanPurchase = request.CanPurchase,
                            CategoryId = request.CategoryId,
                            Code = request.Code,
                            Discount = request.Discount,
                            PriceDiscount = request.PriceDiscount,
                            Price = request.Price,
                            Displayed = request.Displayed,
                            Color = request.Color,
                            EnglishTitle = request.EnglishTitle,
                            Quantity = request.Quantity,

                            ProductImages = ProductImageMapper(request.ProductImages),
                            ProductTechnicals = ProductTechnicalMapper(request.ProductTechnician, request.CreatorUserId.GetValueOrDefault()),
                            ProductFeatures = ProductImageMapper(request.ProductFeatures, request.CreatorUserId.GetValueOrDefault()),
                        };

                        await _repository.AddAsync(mapper);
                        _result.IsSuccess = await _unitOfWork.CommitAsync(cancellationToken) > 0;

                    }
                }
            }
            catch (Exception e)
            {
                _result.AddError(SharedResource.SaveError);
                _result.IsSuccess = false;
            }

            return _result;
        }

        private bool IsValid(ProductsCreateCommand model)
        {
            if (!model.ProductImages.Any())
            {
                _result.AddError(SharedResource.ProductImagesError);
                _result.IsSuccess = false;
            }
            if (!model.ProductFeatures.Any())
            {
                _result.AddError(SharedResource.ProductFeaturesError);
                _result.IsSuccess = false;
            }
            if (!model.ProductTechnician.Any())
            {
                _result.AddError(SharedResource.ProductTechnicianError);
                _result.IsSuccess = false;
            }
            return _result.IsSuccess;
        }

        #region Mapper

        private List<ProductFeature> ProductImageMapper(List<ProductFeaturesCommand> features, int creatorUserId)
        {
            var productFeatures = new List<ProductFeature>();
            foreach (var feature in features)
            {
                productFeatures.Add(new ProductFeature()
                {
                    CreateDate = DateTime.Now,
                    CreatorUserId = creatorUserId,
                    Description = feature.Description,
                    EnglishTitle = feature.EnglishTitle,
                    Title = feature.Title,

                });
            }
            return productFeatures;
        }
        private List<ProductImage> ProductImageMapper(List<ProductImagesCommand> images)
        {
            var productImages = new List<ProductImage>();
            foreach (var image in images)
            {
                productImages.Add(new ProductImage()
                {
                    IsShow = image.IsShow,
                    IsBaseImage = image.IsBaseImage,
                    Src = image.Src
                });
            }
            return productImages;
        }

        private List<ProductTechnical> ProductTechnicalMapper(List<ProductTechnicalCommand> technicals, int creatorUserId)
        {
            var productTechnical = new List<ProductTechnical>();
            foreach (var technical in technicals)
            {
                productTechnical.Add(new ProductTechnical()
                {
                    CreateDate = DateTime.Now,
                    CreatorUserId = creatorUserId,

                    Description = technical.Description,
                    Title = technical.Title

                });
            }
            return productTechnical;
        }

        #endregion

    }
}