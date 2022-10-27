/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{razor,html,cshtml,js}",
    "./RazorPizza/Pages/*.{razor,html,cshtml,js}",
    "./RazorPizza/Pages/**/*.{razor,html,cshtml,js}",
    "./RazorPizza/wwwroot/js/*.{razor,html,cshtml,js}"
  ],
  theme: {
    extend: {},
  },
  plugins: [],
}