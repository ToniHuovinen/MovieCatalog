# MovieCatalog

MovieCatalog

Sourcecodes for my first project, movie catalog. Simple program made with C# to store your movie collection.

I have converted the variables etc. in english, but unfortunately I wasn't able to convert the names of executable files properly, so those are in finnish. UI and the codebehind is in english though.

You can enter the name of the movie, director, release year and genre in their respected fields and by pressing the "Send" button, your movie is transported in the list. If you click the name of the movie, program should fetch the poster, imdb-rating and movie plot from OMDB. I have left the OMDB API key in it's place, but you can fetch your very own key from their site (it's free) and replace that with it if you want.

Whenever you start the program, it reads the catalog.xml file and loads it's contents in to the datagrid. If you choose to ad movies to the list, they are stored in that same catalog.xml when you close the program from that big X on upper right corner.

This project is still little bit work in progress, I will improve upon it time to time and upload newest version here.

Things I still need to fix/solve:

Sometimes program crashes in Visual Studios when clicking on an movie, but it works fine when running as an app. There must be some issues with the code I haven't been able to solve.

Make it so that if there is no catalog.xml available, one is created. Now if you don't have that file, program will crash.

OMDB API brings lot of data in the program, and only IMDB-rating, movie plot and poster is used. So I need to make use of all that data.

Make program draggable. Now it starts in the middle of screen, and you can't really interact with it's position.
