import React, { useState } from 'react';
import { Link } from "react-router-dom";
import axios from "axios";
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
      .post("http://20.241.129.61:5000/api/Products", {
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
  </div>
};

export default AddProducts;
