import React, { useState } from 'react';
import { Link } from "react-router-dom";
import logo from "../assets/images/logo.svg";
import ss from "../assets/images/icons/vegan.png";
import sp from "../assets/images/icons/gluten-free.jpg";
import md from "../assets/images/methods.png"
import df from "../assets/images/icons/dairy-free.avif"
import vg from "../assets/images/icons/carrots.png"
import pl from "../assets/images/icons/paleo-diet.png"
import or from "../assets/images/icons/organic.png"

const AddProducts = () => {

  const [listOfProducts, setListOfProducts] = useState([]);
  const [name, setName] = useState("");
  const [description, setdescription] = useState("");
  const [image, setImage] = useState("");
  const [price, setPrice] = useState("");
  const [stockCount, setStockCount] = useState("");
  const [formErrors, setFormErrors] = useState({});
  const [isSubmit, setIsSubmit] = useState(false);

  const handleSubmit = (e) => {
    e.preventDefault();
    setFormErrors(validate());
    setIsSubmit(true);
    sub();
  };

  const validate = () => {
    const errors = {};
    if (!name) {
      errors.name = "Name is required!";
    }
    if (!description) {
        errors.description = "Description is required!";
    }
    if (!image) {
      errors.image = "Image is required!";
    }
    if (!price) {
        errors.price = "Price is required!";
    }
    if (!stockCount) {
        errors.stockCount = "stockCount is required!";
    }
    return errors;
  };

  const sub = () => {
    if (Object.keys(formErrors).length == 0 && isSubmit) {
      createProd();
    }
  };

  const createProd = () => {
    axios
      .post("http://localhost:8000/api/Products/", {
        name,
        description,
        image,
        price,
        stockCount,
      })
      .then((response) => {
        setListOfProducts([
          ...listOfProducts,
          {
            name,
            description,
            image,
            price,
            stockCount,
          },
        ]);
      });
    swal({
      title: "Product Added Successfuly!",
      icon: "success",
      confirmButtonText: "OK",
    }).then(function () {
      // Redirect the user
      window.location.href = "/";
    });
  };


  return <div>

<div class="container flex items-center justify-between">
            <a href="index.html">
                <img src={logo} alt="Logo" class="w-32"/>
            </a>

            <div class="w-full max-w-xl relative flex">
                <span class="absolute left-4 top-3 text-lg text-gray-400">
                    <i class="fa-solid fa-magnifying-glass"></i>
                </span>
                <input type="text" name="search" id="search"
                    class="w-full border border-primary border-r-0 pl-12 py-3 pr-3 rounded-l-md focus:outline-none"
                    placeholder="search"/>
                <button
                    class="bg-primary border border-primary text-white px-8 rounded-r-md hover:bg-transparent hover:text-primary transition">Search</button>
            </div>

            <div class="flex items-center space-x-4">
                <a href="#" class="text-center text-gray-700 hover:text-primary transition relative">
                    <div class="text-2xl">
                        <i class="fa-regular fa-heart"></i>
                    </div>
                    <div class="text-xs leading-3">Wishlist</div>
                    <div
                        class="absolute right-0 -top-1 w-5 h-5 rounded-full flex items-center justify-center bg-primary text-white text-xs">
                        8</div>
                </a>
                <a href="#" class="text-center text-gray-700 hover:text-primary transition relative">
                    <div class="text-2xl">
                        <i class="fa-solid fa-bag-shopping"></i>
                    </div>
                    <div class="text-xs leading-3">Cart</div>
                    <div
                        class="absolute -right-3 -top-1 w-5 h-5 rounded-full flex items-center justify-center bg-primary text-white text-xs">
                        2</div>
                </a>
                <a href="#" class="text-center text-gray-700 hover:text-primary transition relative">
                    <div class="text-2xl">
                        <i class="fa-regular fa-user"></i>
                    </div>
                    <div class="text-xs leading-3">Account</div>
                </a>
            </div>
        </div>

        <nav class="bg-gray-800">
        <div class="container flex">
            <div class="px-8 py-4 bg-primary flex items-center cursor-pointer relative group">
                <span class="text-white">
                    <i class="fa-solid fa-bars"></i>
                </span>
                <span class="capitalize ml-2 text-white">All Categories</span>

                
                <div
                    class="absolute w-full left-0 top-full bg-white shadow-md py-3 divide-y divide-gray-300 divide-dashed opacity-0 group-hover:opacity-100 transition duration-300 invisible group-hover:visible">
                    <a href="#" class="flex items-center px-6 py-3 hover:bg-gray-100 transition">
                        <img src={ss} alt="sofa" class="w-5 h-5 object-contain"/>
                        <span class="ml-6 text-gray-600 text-sm">vegan</span>
                    </a>
                    <a href="#" class="flex items-center px-6 py-3 hover:bg-gray-100 transition">
                        <img src={sp} alt="terrace" class="w-5 h-5 object-contain"/>
                        <span class="ml-6 text-gray-600 text-sm">Glueten-Free</span>
                    </a>
                    <a href="#" class="flex items-center px-6 py-3 hover:bg-gray-100 transition">
                        <img src={df} alt="bed" class="w-5 h-5 object-contain"/>
                        <span class="ml-6 text-gray-600 text-sm">Diary-Free</span>
                    </a>
                    <a href="#" class="flex items-center px-6 py-3 hover:bg-gray-100 transition">
                        <img src={vg} alt="office" class="w-5 h-5 object-contain"/>
                        <span class="ml-6 text-gray-600 text-sm">Vegetarian</span>
                    </a>
                    <a href="#" class="flex items-center px-6 py-3 hover:bg-gray-100 transition">
                        <img src={pl} alt="outdoor" class="w-5 h-5 object-contain"/>
                        <span class="ml-6 text-gray-600 text-sm">Paleo</span>
                    </a>
                    <a href="#" class="flex items-center px-6 py-3 hover:bg-gray-100 transition">
                        <img src={or} alt="Mattress" class="w-5 h-5 object-contain"/>
                        <span class="ml-6 text-gray-600 text-sm">Organic</span>
                    </a>
                </div>
            </div>

            <div class="flex items-center justify-between flex-grow pl-12">
                <div class="flex items-center space-x-6 capitalize">
                    <a href="index.html" class="text-gray-200 hover:text-white transition">Home</a>
                    <a href="pages/shop.html" class="text-gray-200 hover:text-white transition">Shop</a>
                    <a href="#" class="text-gray-200 hover:text-white transition">About us</a>
                    <a href="#" class="text-gray-200 hover:text-white transition">Contact us</a>
                </div>
                <a href="pages/login.html" class="text-gray-200 hover:text-white transition">Login</a>
            </div>
        </div>
    </nav>
    <form class="form-horizontal">
<fieldset>
        
<legend>PRODUCTS</legend>


<div class="form-group">
  <label class="col-md-4 control-label" for="product_name">PRODUCT NAME</label>  
  <div class="col-md-4">
  <input id="product_name" name="product_name" placeholder="PRODUCT NAME" class="form-control input-md" required="" type="text"
  onChange={(e) => {
    setName(e.target.value);
  }}
  />
    
  </div>
</div>

<div class="form-group">
  <label class="col-md-4 control-label" for="product_description">PRODUCT DESCRIPTION</label>
  <div class="col-md-4">                     
    <textarea class="form-control" id="product_description" name="product_description" placeholder="PRODUCT DESCRIPTION"
    required
    value={description}
    onChange={(e) => {
    setdescription(e.target.value);
    }}
    ></textarea>
  </div>
</div>


<div class="form-group">
  <label class="col-md-4 control-label" for="product_image">Image</label>  
  <div class="col-md-4">
  <input id="product_image" name="product_image" placeholder="PRODUCT IMAGE" class="form-control input-md" required="" type="text" 
   value={image}
   onChange={(e) => {
     setImage(e.target.value);
   }}
  />
    
  </div>
</div>

<div class="form-group">
  <label class="col-md-4 control-label" for="product_price">PRODUCT PRICE</label>  
  <div class="col-md-4">
  <input id="product_price" name="product_price" placeholder="PRODUCT PRICE" class="form-control input-md" required="" type="text"
  value={price}
  onChange={(e) => {
  setPrice(e.target.value);
  }}
  />
    
  </div>
</div>


<div class="form-group">
  <label class="col-md-4 control-label" for="stock_quantity">STOCK QUANTITY</label>  
  <div class="col-md-4">
  <input id="stock_quantity" name="stock_quantity" placeholder="STOCK QUANTITY" class="form-control input-md" required="" type="text"
  value={stockCount}
  onChange={(e) => {
  setStockCount(e.target.value);
  }}/>
    
  </div>
</div>

<div class="row justify-content-end" id="add-btn">
            <center>
              <Link to="/">
                {" "}
                <button
                  type="button"
                  onClick={handleSubmit}
                  class="btn-block btn-primary"
                  style={{ backgroundColor: "#0C1559", width:"100px"}}
                >
                  Submit
                </button>
              </Link>{" "}
            </center>
          </div>

  </fieldset>
</form>

<br/>

<footer class="bg-white pt-16 pb-12 border-t border-gray-100">
        <div class="container grid grid-cols-3">
            <div class="col-span-1 space-y-8 mr-2">
                
                
            </div>

            <div class="col-span-2 grid grid-cols-2 gap-8">
                <div class="grid grid-cols-2 gap-8">
                    <div style={{marginLeft:"100px"}}>
                        <h3 class="text-sm font-semibold text-gray-400 uppercase tracking-wider">Solutions</h3>
                        <div class="mt-4 space-y-4" >
                            <a href="#" class="text-base text-gray-500 hover:text-gray-900 block" >Marketing</a>
                            <a href="#" class="text-base text-gray-500 hover:text-gray-900 block">Analitycs</a>
                            <a href="#" class="text-base text-gray-500 hover:text-gray-900 block">Commerce</a>
                            <a href="#" class="text-base text-gray-500 hover:text-gray-900 block">Insights</a>
                        </div>
                    </div>

                    <div style={{marginLeft:"200px"}}>
                        <h3 class="text-sm font-semibold text-gray-400 uppercase tracking-wider">Support</h3>
                        <div class="mt-4 space-y-4">
                            <a href="#" class="text-base text-gray-500 hover:text-gray-900 block">Pricing</a>
                            <a href="#" class="text-base text-gray-500 hover:text-gray-900 block">Documentation</a>
                            <a href="#" class="text-base text-gray-500 hover:text-gray-900 block">Guides</a>
                            <a href="#" class="text-base text-gray-500 hover:text-gray-900 block">API Status</a>
                        </div>
                    </div>
                </div>
                <div class="grid grid-cols-2 gap-8">
                    <div style={{marginLeft:"300px"}}>
                        <h3 class="text-sm font-semibold text-gray-400 uppercase tracking-wider">Solutions</h3>
                        <div class="mt-4 space-y-4">
                            <a href="#" class="text-base text-gray-500 hover:text-gray-900 block">Marketing</a>
                            <a href="#" class="text-base text-gray-500 hover:text-gray-900 block">Analitycs</a>
                            <a href="#" class="text-base text-gray-500 hover:text-gray-900 block">Commerce</a>
                            <a href="#" class="text-base text-gray-500 hover:text-gray-900 block">Insights</a>
                        </div>
                    </div>

                    <div style={{marginLeft:"400px"}}>
                        <h3 class="text-sm font-semibold text-gray-400 uppercase tracking-wider">Support</h3>
                        <div class="mt-4 space-y-4">
                            <a href="#" class="text-base text-gray-500 hover:text-gray-900 block">Pricing</a>
                            <a href="#" class="text-base text-gray-500 hover:text-gray-900 block">Documentation</a>
                            <a href="#" class="text-base text-gray-500 hover:text-gray-900 block">Guides</a>
                            <a href="#" class="text-base text-gray-500 hover:text-gray-900 block">API Status</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </footer>

    <div class="bg-gray-800 py-4">
        <div class="container flex items-center justify-between">
            <p class="text-white">&copy; TailCommerce - All Right Reserved</p>
            <div>
                <img src={md} alt="methods" class="h-5"/>
            </div>
        </div>
    </div>
  </div>
};

export default AddProducts;
