# PeezyMovies
ASP.NET MVC WEB APP 


# 🔨 Used technologies
* ASP.NET MVC version: 6.0
* ASP.NET Core areas
* Entity Framework CORE 6.0
* Bootstrap
* SendGrid
* SendGrid Widget
* HTML & CSS
* HtmlSanitizer
* JavaScript
* AJAX real-time Requests
* jQuery plugins (bootstrap-select)
* Facebook for developers
* YouTube
* xUnit
* ASP.NET Identity
* Google maps for developers
* CORS

# 📝 Project Description EN


The web application provides modern project for work. The application combines a lot of functionality which can be useful for all types of users. In the navbar there is easy menu: “Top Movies Worldwide”, “Movies”, “Contacts” "About", "Dropdown" – with a dropping menu, “Actors”, “Producers”, "Cinemas". Tight to this navbar there is a search bar which can find the requested information from the user using searching in the whole system. On the right side in the section there is also the User's typically buttons where guests can register and logIn. There is also an option for login with external login provider(facebook) to the system, in the future there will be more external providers. Now let’s continue with a brief description for each of the pages when a guests register a user.

Description of the “Home” page: In an interactive slider there is a visualization of last three movies from the whole database. Each of the movies in this slider contains mini button for which send the users to the movie's trailer. The Action uses InMemoryCache to get the cache for the movies in period of 15 minutes.


Description of the “Movies” page: In this page with a tabular view are presented 4 movies per page with pagging buttons and more two buttons showing the sorting logic which can be chosen between 3 options - Rating/Price/Genre and more 1 button to show which Genre where users can see all the movies in the application with that genre. Under the table there are more buttons/redirect actions which help to get best user experience. Trailer button - redirect to page with current movie's trailer.
When guest register he got more two tabs when user is authenticated that is "Watched" and "Chat" where with the second button when user already had watched a movie can add it to the watchlist pannel. Details - users can see details about the movie like genre/price/director/producer/actors/cinema and more.
The last button is "add to cart" - there is implemented a shopping cart maded with sessions and viewComponent. users get notification when added item to the cart.


For more convenient use above the search bar there is a paging with letters and digits. The most essential information is showed briefly in the table for each movie. When the movie poster is clicked, the user is sent to the page for the given movie, where he can get more information about it.

Description of the “Contacts” page: The page is simply a form, where the user can send emails via integrated SendGrid if they have a question or a problem. The emails gets directly to the admin's email and so for ease of use there is again a integrated map with js.

Description of the “About” page: The page shows simply info about the project and a AJAX demo used to get all actors info without refreshing the page.

Description of the “Watched” page: The page is the Watchlist where users add movies.

Description of the “Chat” page: The page is a globally chat where users can chat and use their nicknames.


Description of administrator panel: Like other systems here there is an administrator panel where the admin can add, delete, edit information about the system. In section “User’s Administration” for ease of use the administrator can see all the user's info and delete/update/add movies.
There is a "Add Movie" part in the navbar when administrator log in where he can add movies, also he can delete/ban users to prevent login in the site.

Description of the user profile: For the user profile there is a standard functionality which is provided by ASP.NET Core Identity.

Additional functionalities:  There is also Facebook login which can be used instead of standard registration.

In conclusion: Peezy Movies is a mini-movies project which combines in one place convenient user interface, chance to look for movies, news for them and details.In future there is a plan for developing a real system for ticket payment which is almost ready and form for movie reviews also reservation of tickets in real time. The purpose of the system is to be similar to IMDB.


# Database 


![image](https://user-images.githubusercontent.com/96740451/207843980-fd22bacc-162d-4378-9032-2cd86e9cdd44.png)
