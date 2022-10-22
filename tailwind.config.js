/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{cshtml,js}",
    "./RazorPizza/Pages/*.{cshtml,js}",
    "./RazorPizza/Pages/**/*.{cshtml,js}",
    "./RazorPizza/wwwroot/js/*.{cshtml,js}"
  ],
  theme: {
    extend: {},
  },
  plugins: [],
}