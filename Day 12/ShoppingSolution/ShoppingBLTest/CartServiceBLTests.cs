﻿using ShoppingBLLibrary;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLTest
{
    public class CartServiceBLTests
    {
        private IRepository<int, Cart> _cartRepository;
        private IRepository<int, Product> _productRepository;
        private IRepository<int, Customer> _customerRepository;
        private ICartService _cartService;
        private ICustomerService _customerService;
        private IProductService _productService;

        [SetUp]
        public void Setup()
        {
            _cartRepository = new CartRepository();
            _productRepository = new ProductRepository();
            _customerRepository = new CustomerRepository();
            _cartService = new CartService(_cartRepository, _productRepository, _customerRepository);
            _customerService = new CustomerServiceBL(_customerRepository);
            _productService = new ProductServiceBL(_productRepository);
        }

        [Test]
        public void AddProductToCart_ValidInputs_Success()
        {
            // Arrange
            int quantity1 = 3;
            int quantity2 = 4;
            int quantity3 = 1;

            Customer customer = new Customer { Id = 1, Name = "John Doe", Age = 30, Phone = "1234567890" };
            Customer addedCustomer = _customerService.AddCustomer(customer);
            Assert.That(addedCustomer, Is.EqualTo(customer));

            //Products to add to cart

            Product product1 = new Product { Id = 1, Name = "Laptop", Price = 100000, QuantityInHand = 80 };
            Product addedProduct1 = _productService.AddProduct(product1);
            Assert.That(addedProduct1, Is.EqualTo(product1));
            
            Product product2 = new Product { Id = 2, Name = "Phone", Price = 5000, QuantityInHand = 80 };
            Product addedProduct2 = _productService.AddProduct(product2);
            Assert.That(addedProduct2, Is.EqualTo(product2));
            
            Product product3 = new Product { Id = 3, Name = "Earphone", Price = 1200, QuantityInHand = 80 };
            Product addedProduct3 = _productService.AddProduct(product3);
            Assert.That(addedProduct3, Is.EqualTo(product3));
                

            // Act
            Cart result1 = _cartService.AddProductToCart(customer.Id, addedProduct1.Id, quantity1);
            Console.WriteLine(result1.ToString());
            Assert.IsNotNull(result1);

            Cart result2 = _cartService.AddProductToCart(customer.Id, addedProduct2.Id, quantity2);
            Assert.IsNotNull(result2);
            
            Cart result3 = _cartService.AddProductToCart(customer.Id, addedProduct3.Id, quantity3);
            Console.WriteLine(result3.ToString());
            Assert.IsNotNull(result3);
            // Assert
            Assert.That(result1.CartItems.Count, Is.EqualTo(3));
        }

        [Test]
        public void AddProductToCart_InvalidProduct_Fails()
        {
            // Arrange
            int quantity = 3;
            int productId = 1;
            int customerId = 1;

            Customer customer = new Customer { Id = 1, Name = "John Doe", Age = 30, Phone = "1234567890" };
            Customer addedCustomer = _customerService.AddCustomer(customer);
            Assert.That(addedCustomer, Is.EqualTo(customer));

            // Act & Assert
            Assert.Throws<NoProductWithGiveIdException>(() => _cartService.AddProductToCart(customerId, productId, quantity));
        }

        [Test]
        public void AddProductToCart_MaxQuantityExceeded_Fails()
        {
            // Arrange
            int quantity = 6;

            Customer customer = new Customer { Id = 1, Name = "John Doe", Age = 30, Phone = "1234567890" };
            Customer addedCustomer = _customerService.AddCustomer(customer);
            Assert.That(addedCustomer, Is.EqualTo(customer));

            Product product = new Product { Id = 1, Name = "Laptop", Price = 100000, QuantityInHand = 80 };
            Product addedProduct = _productService.AddProduct(product);
            Assert.That(addedProduct, Is.EqualTo(product));

            // Act & Assert
            Assert.Throws<MaxQuantityExceededException>(() => _cartService.AddProductToCart(customer.Id, addedProduct.Id, quantity));
        }

        [Test]
        public void AddProductToCart_ProductQuantityNotAvailable_Fails()
        {
            // Arrange
            int quantity = 4;

            Customer customer = new Customer { Id = 1, Name = "John Doe", Age = 30, Phone = "1234567890" };
            Customer addedCustomer = _customerService.AddCustomer(customer);
            Assert.That(addedCustomer, Is.EqualTo(customer));

            Product product = new Product { Id = 1, Name = "Laptop", Price = 100000, QuantityInHand = 2 };
            Product addedProduct = _productService.AddProduct(product);
            Assert.That(addedProduct, Is.EqualTo(product));

            // Act & Assert
            Assert.Throws<ProductQuantityNotAvailableException>(() => _cartService.AddProductToCart(customer.Id, addedProduct.Id, quantity));
        }

        [Test]
        public void UpdateCartItemQuantity_ValidInputs_Success()
        {
            // Arrange
            int quantity1 = 3;
            int quantity2 = 4;
            int quantity3 = 1;

            Customer customer = new Customer { Id = 1, Name = "John Doe", Age = 30, Phone = "1234567890" };
            Customer addedCustomer = _customerService.AddCustomer(customer);
            Assert.That(addedCustomer, Is.EqualTo(customer));

            //Products to add to cart

            Product product1 = new Product { Id = 1, Name = "Laptop", Price = 100000, QuantityInHand = 80 };
            Product addedProduct1 = _productService.AddProduct(product1);
            Assert.That(addedProduct1, Is.EqualTo(product1));

            Product product2 = new Product { Id = 2, Name = "Phone", Price = 5000, QuantityInHand = 80 };
            Product addedProduct2 = _productService.AddProduct(product2);
            Assert.That(addedProduct2, Is.EqualTo(product2));

            Product product3 = new Product { Id = 3, Name = "Earphone", Price = 1200, QuantityInHand = 80 };
            Product addedProduct3 = _productService.AddProduct(product3);
            Assert.That(addedProduct3, Is.EqualTo(product3));


            // Act
            Cart result1 = _cartService.AddProductToCart(customer.Id, addedProduct1.Id, quantity1);
            Console.WriteLine(result1.ToString());
            Assert.IsNotNull(result1);

            Cart result2 = _cartService.AddProductToCart(customer.Id, addedProduct2.Id, quantity2);
            Assert.IsNotNull(result2);

            Cart result3 = _cartService.AddProductToCart(customer.Id, addedProduct3.Id, quantity3);
            Console.WriteLine(result3.ToString());
            Assert.IsNotNull(result3);

            // Act
            Cart updatedCart = _cartService.UpdateCartItemQuantity(result1.Id, addedProduct1.Id, 5);
            Console.WriteLine(updatedCart.ToString());
            Assert.IsNotNull(updatedCart);

            // Assert
            Assert.That(updatedCart.CartItems[0].Quantity, Is.EqualTo(5));
        }
        [Test]
        public void UpdateCartItemQuantity_InvalidCartId_Fails()
        {
            // Arrange
            int quantity = 3;
            int productId = 1;
            int customerId = 1;

            Customer customer = new Customer { Id = 1, Name = "John Doe", Age = 30, Phone = "1234567890" };
            Customer addedCustomer = _customerService.AddCustomer(customer);
            Assert.That(addedCustomer, Is.EqualTo(customer));

            // Act & Assert
            Assert.Throws<CartNotFoundException>(() => _cartService.UpdateCartItemQuantity(customerId, productId, quantity));
        }

        [Test]
        public void UpdateCartItemQuantity_InvalidProductId_Fails()
        {
            // Arrange
            int quantity = 3;
            int productId = 5;

            Product product1 = new Product { Id = 1, Name = "Laptop", Price = 100000, QuantityInHand = 80 };
            Product addedProduct1 = _productService.AddProduct(product1);
            Assert.That(addedProduct1, Is.EqualTo(product1));

            Customer customer = new Customer { Id = 1, Name = "John Doe", Age = 30, Phone = "1234567890" };
            Customer addedCustomer = _customerService.AddCustomer(customer);
            Assert.That(addedCustomer, Is.EqualTo(customer));

            Cart cart = _cartService.AddProductToCart(addedCustomer.Id, product1.Id, 2);


            // Act & Assert
            Assert.Throws<CartItemNotFoundException>(() => _cartService.UpdateCartItemQuantity(addedCustomer.Id, productId, quantity));
        }
        [Test]
        public void UpdateCartItemQuantity_MaxQuantityExceeded_Fails()
        {
            // Arrange
            int quantity = 6;

            Customer customer = new Customer { Id = 1, Name = "John Doe", Age = 30, Phone = "1234567890" };
            Customer addedCustomer = _customerService.AddCustomer(customer);
            Assert.That(addedCustomer, Is.EqualTo(customer));

            Product product = new Product { Id = 1, Name = "Laptop", Price = 100000, QuantityInHand = 80 };
            Product addedProduct = _productService.AddProduct(product);
            Assert.That(addedProduct, Is.EqualTo(product));

            Cart cart = _cartService.AddProductToCart(customer.Id, addedProduct.Id, 3);
            Assert.IsNotNull(cart);

            // Act & Assert
            Assert.Throws<MaxQuantityExceededException>(() => _cartService.UpdateCartItemQuantity(cart.Id, addedProduct.Id, quantity));
        }

        [Test]
        public void UpdateCartItemQuantity_ProductQuantityNotAvailable_Fails()
        {
            // Arrange
            int quantity = 4;

            Customer customer = new Customer { Id = 1, Name = "John Doe", Age = 30, Phone = "1234567890" };
            Customer addedCustomer = _customerService.AddCustomer(customer);
            Assert.That(addedCustomer, Is.EqualTo(customer));

            Product product = new Product { Id = 1, Name = "Laptop", Price = 100000, QuantityInHand = 2 };
            Product addedProduct = _productService.AddProduct(product);
            Assert.That(addedProduct, Is.EqualTo(product));

            Cart cart = _cartService.AddProductToCart(customer.Id, addedProduct.Id, 1);
            Assert.IsNotNull(cart);

            // Act & Assert
            Assert.Throws<ProductQuantityNotAvailableException>(() => _cartService.UpdateCartItemQuantity(cart.Id, addedProduct.Id, quantity));
        }
        [Test]
        public void RemoveProductFromCart_ValidInputs_Success()
        {
            // Arrange
            int quantity1 = 3;
            int quantity2 = 4;
            int quantity3 = 1;

            Customer customer = new Customer { Id = 1, Name = "John Doe", Age = 30, Phone = "1234567890" };
            Customer addedCustomer = _customerService.AddCustomer(customer);
            Assert.That(addedCustomer, Is.EqualTo(customer));

            //Products to add to cart

            Product product1 = new Product { Id = 1, Name = "Laptop", Price = 100000, QuantityInHand = 80 };
            Product addedProduct1 = _productService.AddProduct(product1);
            Assert.That(addedProduct1, Is.EqualTo(product1));

            Product product2 = new Product { Id = 2, Name = "Phone", Price = 5000, QuantityInHand = 80 };
            Product addedProduct2 = _productService.AddProduct(product2);
            Assert.That(addedProduct2, Is.EqualTo(product2));

            Product product3 = new Product { Id = 3, Name = "Earphone", Price = 1200, QuantityInHand = 80 };
            Product addedProduct3 = _productService.AddProduct(product3);
            Assert.That(addedProduct3, Is.EqualTo(product3));
        }

        [Test]
        public void RemoveProductFromCart_InvalidCartId_Fails()
        {
            // Arrange
            int productId = 1;
            int customerId = 1;

            Customer customer = new Customer { Id = 1, Name = "John Doe", Age = 30, Phone = "1234567890" };
            Customer addedCustomer = _customerService.AddCustomer(customer);
            Assert.That(addedCustomer, Is.EqualTo(customer));

            // Act & Assert
            Assert.Throws<CartNotFoundException>(() => _cartService.RemoveProductFromCart(customerId, productId));
        }
        [Test]
        public void RemoveProductFromCart_InvalidProductId_Fails()
        {
            // Arrange
            int productId = 2;
            int customerId = 1;
            Product product1 = new Product { Id = 1, Name = "Laptop", Price = 100000, QuantityInHand = 80 };
            Product addedProduct1 = _productService.AddProduct(product1);
            Assert.That(addedProduct1, Is.EqualTo(product1));

            Customer customer = new Customer { Id = 1, Name = "John Doe", Age = 30, Phone = "1234567890" };
            Customer addedCustomer = _customerService.AddCustomer(customer);
            Assert.That(addedCustomer, Is.EqualTo(customer));

            Cart cart = _cartService.AddProductToCart(customer.Id, addedProduct1.Id, 3);
            // Act & Assert
            Assert.Throws<CartItemNotFoundException>(() => _cartService.RemoveProductFromCart(customerId, productId));
        }
        [Test]
        public void GetCartById_ValidInputs_Success()
        {
            // Arrange
            int quantity1 = 3;
            int quantity2 = 4;
            int quantity3 = 1;

            Customer customer = new Customer { Id = 1, Name = "John Doe", Age = 30, Phone = "1234567890" };
            Customer addedCustomer = _customerService.AddCustomer(customer);
            Assert.That(addedCustomer, Is.EqualTo(customer));

            //Products to add to cart

            Product product1 = new Product { Id = 1, Name = "Laptop", Price = 100000, QuantityInHand = 80 };
            Product addedProduct1 = _productService.AddProduct(product1);
            Assert.That(addedProduct1, Is.EqualTo(product1));

            Product product2 = new Product { Id = 2, Name = "Phone", Price = 5000, QuantityInHand = 80 };
            Product addedProduct2 = _productService.AddProduct(product2);
            Assert.That(addedProduct2, Is.EqualTo(product2));

            Product product3 = new Product { Id = 3, Name = "Earphone", Price = 1200, QuantityInHand = 80 };
            Product addedProduct3 = _productService.AddProduct(product3);
            Assert.That(addedProduct3, Is.EqualTo(product3));

            // Act
            Cart result1 = _cartService.AddProductToCart(customer.Id, addedProduct1.Id, quantity1);
            Console.WriteLine(result1.ToString());
            Assert.IsNotNull(result1);

            Cart result2 = _cartService.AddProductToCart(customer.Id, addedProduct2.Id, quantity2);
            Assert.IsNotNull(result2);

            Cart result3 = _cartService.AddProductToCart(customer.Id, addedProduct3.Id, quantity3);
            Console.WriteLine(result3.ToString());
            Assert.IsNotNull(result3);

            // Act
            Cart retrievedCart = _cartService.GetCartById(result1.Id);
            Console.WriteLine(retrievedCart.ToString());
            Assert.IsNotNull(retrievedCart);

            // Assert
            Assert.That(retrievedCart, Is.EqualTo(result1));
        }
        [Test]
        public void GetCartById_InvalidCartId_Fails()
        {
            // Arrange
            int Id = 1;

            // Act & Assert
            Assert.Throws<CartNotFoundException>(() => _cartService.GetCartById(Id));
        }
        [Test]
        public void GetAllCartItems_ValidInputs_Success()
        {
            // Arrange
            int quantity1 = 3;
            int quantity2 = 4;
            int quantity3 = 1;

            Customer customer = new Customer { Id = 1, Name = "John Doe", Age = 30, Phone = "1234567890" };
            Customer addedCustomer = _customerService.AddCustomer(customer);
            Assert.That(addedCustomer, Is.EqualTo(customer));

            //Products to add to cart

            Product product1 = new Product { Id = 1, Name = "Laptop", Price = 100000, QuantityInHand = 80 };
            Product addedProduct1 = _productService.AddProduct(product1);
            Assert.That(addedProduct1, Is.EqualTo(product1));

            Product product2 = new Product { Id = 2, Name = "Phone", Price = 5000, QuantityInHand = 80 };
            Product addedProduct2 = _productService.AddProduct(product2);
            Assert.That(addedProduct2, Is.EqualTo(product2));

            Product product3 = new Product { Id = 3, Name = "Earphone", Price = 1200, QuantityInHand = 80 };
            Product addedProduct3 = _productService.AddProduct(product3);
            Assert.That(addedProduct3, Is.EqualTo(product3));

            // Act
            Cart result1 = _cartService.AddProductToCart(customer.Id, addedProduct1.Id, quantity1);
            Console.WriteLine(result1.ToString());
            Assert.IsNotNull(result1);

            Cart result2 = _cartService.AddProductToCart(customer.Id, addedProduct2.Id, quantity2);
            Assert.IsNotNull(result2);

            Cart result3 = _cartService.AddProductToCart(customer.Id, addedProduct3.Id, quantity3);
            Console.WriteLine(result3.ToString());
            Assert.IsNotNull(result3);

            // Act
            Cart cart = _cartService.GetCartById(result3.Id);
           
            Assert.IsNotNull(cart);

            // Assert
            Console.WriteLine(cart);
            Assert.That(cart.CartItems.Count, Is.EqualTo(3));
        }

        [Test]
        public void GetAllCarts_NoCartsAvailable_ReturnsEmptyList()
        {
            // Arrange

            // Act
            List<Cart> carts = _cartService.GetAllCarts();
            Console.WriteLine(carts);
            Assert.IsNotNull(carts);

            // Assert
            Assert.That(carts.Count, Is.EqualTo(0));
        }
        [Test]
        public void GetAllCarts_InvalidCartId_Fails()
        {
            // Arrange
            int cartId = 1;

            // Act & Assert
            Assert.Throws<CartNotFoundException>(() => _cartService.GetCartById(cartId));
        }

    }
}

