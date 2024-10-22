// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const validateEmail = (email) => {
  var pattern = new RegExp(/^\S+@\S+\.\S+$/);
  return pattern.test(email);
};