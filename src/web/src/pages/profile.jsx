import React from "react";
import logo from "../assets/images/logo.svg";
import ss from "../assets/images/icons/vegan.png";
import sp from "../assets/images/icons/gluten-free.jpg";
import sd from "../assets/images/icons/delivery-van.svg"
import sh from "../assets/images/icons/service-hours.svg"
import mb from "../assets/images/icons/money-back.svg"
import cat1 from "../assets/images/icons/vegan.png"
import cat2 from "../assets/images/icons/gluten-free.jpg"
import cat3 from "../assets/images/icons/dairy-free.avif"
import cat4 from "../assets/images/icons/carrots.png"
import cat5 from "../assets/images/icons/paleo-diet.png"
import cat6 from "../assets/images/icons/organic.png"
import md from "../assets/images/methods.png"
import df from "../assets/images/icons/dairy-free.avif"
import vg from "../assets/images/icons/carrots.png"
import pl from "../assets/images/icons/paleo-diet.png"
import or from "../assets/images/icons/organic.png"
import avatar from "../assets/images/avatar.png"

const Profile = () => {
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

    <div class="container py-4 flex items-center gap-3">
        <a href="../index.html" class="text-primary text-base">
            <i class="fa-solid fa-house"></i>
        </a>
        <span class="text-sm text-gray-400">
            <i class="fa-solid fa-chevron-right"></i>
        </span>
        <p class="text-gray-600 font-medium">Profile</p>
    </div>

    <div class="container grid grid-cols-12 items-start gap-6 pt-4 pb-16">

       
        <div class="col-span-3">
            <div class="px-4 py-3 shadow flex items-center gap-4">
                <div class="flex-shrink-0">
                    <img src={avatar} alt="profile"
                        class="rounded-full w-14 h-14 border border-gray-200 p-1 object-cover"/>
                </div>
                <div class="flex-grow">
                    <p class="text-gray-600">Hello,</p>
                    <h4 class="text-gray-800 font-medium">John Doe</h4>
                </div>
            </div>

            <div class="mt-6 bg-white shadow rounded p-4 divide-y divide-gray-200 space-y-4 text-gray-600">
                <div class="space-y-1 pl-8">
                    <a href="#" class="relative text-primary block font-medium capitalize transition">
                        <span class="absolute -left-8 top-0 text-base">
                            <i class="fa-regular fa-address-card"></i>
                        </span>
                        Manage account
                    </a>
                    <a href="#" class="relative hover:text-primary block capitalize transition">
                        Profile information
                    </a>
                    <a href="#" class="relative hover:text-primary block capitalize transition">
                        Manage addresses
                    </a>
                    <a href="#" class="relative hover:text-primary block capitalize transition">
                        Change password
                    </a>
                </div>

                <div class="space-y-1 pl-8 pt-4">
                    <a href="#" class="relative hover:text-primary block font-medium capitalize transition">
                        <span class="absolute -left-8 top-0 text-base">
                            <i class="fa-solid fa-box-archive"></i>
                        </span>
                        My order history
                    </a>
                    <a href="#" class="relative hover:text-primary block capitalize transition">
                        My returns
                    </a>
                    <a href="#" class="relative hover:text-primary block capitalize transition">
                        My Cancellations
                    </a>
                    <a href="#" class="relative hover:text-primary block capitalize transition">
                        My reviews
                    </a>
                </div>

                <div class="space-y-1 pl-8 pt-4">
                    <a href="#" class="relative hover:text-primary block font-medium capitalize transition">
                        <span class="absolute -left-8 top-0 text-base">
                            <i class="fa-regular fa-credit-card"></i>
                        </span>
                        Payment methods
                    </a>
                    <a href="#" class="relative hover:text-primary block capitalize transition">
                        voucher
                    </a>
                </div>

                <div class="space-y-1 pl-8 pt-4">
                    <a href="#" class="relative hover:text-primary block font-medium capitalize transition">
                        <span class="absolute -left-8 top-0 text-base">
                            <i class="fa-regular fa-heart"></i>
                        </span>
                        My wishlist
                    </a>
                </div>

                <div class="space-y-1 pl-8 pt-4">
                    <a href="#" class="relative hover:text-primary block font-medium capitalize transition">
                        <span class="absolute -left-8 top-0 text-base">
                            <i class="fa-solid fa-right-from-bracket"></i>
                        </span>
                        Logout
                    </a>
                </div>

            </div>
        </div>
        
        <div class="col-span-9 shadow rounded px-6 pt-5 pb-7">
            <h4 class="text-lg font-medium capitalize mb-4">
                Profile information
            </h4>
            <div class="space-y-4">
                <div class="grid grid-cols-2 gap-4">
                    <div>
                        <label for="first">First name</label>
                        <input type="text" name="first" id="first" class="input-box"/>
                    </div>
                    <div>
                        <label for="last">Last name</label>
                        <input type="text" name="last" id="last" class="input-box"/>
                    </div>
                </div>
                <div class="grid grid-cols-2 gap-4">
                    <div>
                        <label for="birthday">Birthday</label>
                        <input type="date" name="birthday" id="birthday" class="input-box"/>
                    </div>
                    <div>
                        <label for="gender">Gender</label>
                        <select name="gender" id="gender" class="input-box">
                            <option value="male">Male</option>
                            <option value="female">Female</option>
                        </select>
                    </div>
                </div>
                <div class="grid grid-cols-2 gap-4">
                    <div>
                        <label for="email">Email Address</label>
                        <input type="email" name="email" id="email" class="input-box"/>
                    </div>
                    <div>
                        <label for="phone">Phone number</label>
                        <input type="text" name="phone" id="phone" class="input-box"/>
                    </div>
                </div>
            </div>

            <div class="mt-4">
                <button type="submit"
                    class="py-3 px-4 text-center text-white bg-primary border border-primary rounded-md hover:bg-transparent hover:text-primary transition font-medium">save
                    changes</button>
            </div>
        </div>
       

    </div>

    <footer class="bg-white pt-16 pb-12 border-t border-gray-100">
        <div class="container grid grid-cols-3">
            <div class="col-span-1 space-y-8 mr-2">
                <img src={logo} alt="logo" class="w-30"/>
                <div class="mr-2">
                    <p class="text-gray-500">
                        Lorem ipsum dolor sit amet consectetur adipisicing elit. Quia, hic?
                    </p>
                </div>
                <div class="flex space-x-6">
                    <a href="#" class="text-gray-400 hover:text-gray-500"><i
                            class="fa-brands fa-facebook-square"></i></a>
                    <a href="#" class="text-gray-400 hover:text-gray-500"><i
                            class="fa-brands fa-instagram-square"></i></a>
                    <a href="#" class="text-gray-400 hover:text-gray-500"><i
                            class="fa-brands fa-twitter-square"></i></a>
                    <a href="#" class="text-gray-400 hover:text-gray-500">
                        <i class="fa-brands fa-github-square"></i>
                    </a>
                </div>
            </div>

            <div class="col-span-2 grid grid-cols-2 gap-8">
                <div class="grid grid-cols-2 gap-8">
                    <div>
                        <h3 class="text-sm font-semibold text-gray-400 uppercase tracking-wider">Solutions</h3>
                        <div class="mt-4 space-y-4">
                            <a href="#" class="text-base text-gray-500 hover:text-gray-900 block">Marketing</a>
                            <a href="#" class="text-base text-gray-500 hover:text-gray-900 block">Analitycs</a>
                            <a href="#" class="text-base text-gray-500 hover:text-gray-900 block">Commerce</a>
                            <a href="#" class="text-base text-gray-500 hover:text-gray-900 block">Insights</a>
                        </div>
                    </div>

                    <div>
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
                    <div>
                        <h3 class="text-sm font-semibold text-gray-400 uppercase tracking-wider">Solutions</h3>
                        <div class="mt-4 space-y-4">
                            <a href="#" class="text-base text-gray-500 hover:text-gray-900 block">Marketing</a>
                            <a href="#" class="text-base text-gray-500 hover:text-gray-900 block">Analitycs</a>
                            <a href="#" class="text-base text-gray-500 hover:text-gray-900 block">Commerce</a>
                            <a href="#" class="text-base text-gray-500 hover:text-gray-900 block">Insights</a>
                        </div>
                    </div>

                    <div>
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



  </div>;
};

export default Profile;
