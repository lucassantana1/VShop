﻿using AutoMapper;

namespace VShop.ProductApi;

public class ProductService : IProductService
{
  private readonly IMapper _mapper;
  private IProductRepository _productRepository;

  public ProductService(IMapper mapper, IProductRepository productRepository)
  {
    _mapper = mapper;
    _productRepository = productRepository;
  }

  public async Task AddProduct(ProductDTO productDto)
  {
    var productEntity = _mapper.Map<Product>(productDto);
    await _productRepository.Create(productEntity);
    productDto.ProductId = productEntity.ProductId;
  }

  public async Task<ProductDTO> GetProductById(int id)
  {
    var productEntity = await _productRepository.GetById(id);
    return _mapper.Map<ProductDTO>(productEntity);
  }

  public async Task<IEnumerable<ProductDTO>> GetProducts()
  {
    var productsEntity = await _productRepository.GetAll();
    return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
  }

  public async Task RemoveProduct(int id)
  {
    var productEntity = _productRepository.GetById(id).Result;
    await _productRepository.Delete(productEntity.ProductId);
  }

  public async Task UpdateProduct(ProductDTO productDto)
  {
    var categoriesEntity = _mapper.Map<Product>(productDto);
    await _productRepository.Update(categoriesEntity);
  }
}
