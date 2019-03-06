# Koke

Koke is a web scraper based on HtmlAgilityPack.

Koke was designed for a very specific use. Here a list of "supported" websites:
* [Comuni Italiani](http://www.comuni-italiani.it/012/lista.html): page like this contains information about italian cities
* [Comuni Ticino](https://it.wikipedia.org/wiki/Comuni_del_Canton_Ticino): this page contains information about Ticino Canton in Switzerland

At this moment, Koke can find informations about city in page like : Koke extract only the list of cities.

# Command line

Koke work with command line: you can pass how many urls you want and then Koke print them on your console.

If you want to save the results, you can specify as last parameter '-txt' or '-xml' to specify the file type.

You have to specify the working mode: working mode is the "type" of urls you have submitted to Koke.
Available working modes:
* 0: Comuni Italiani
* 1: Comuni Ticino


Generic command: ```./KokeScraper urls working_mode [file_type]```

Here some examples of Koke execution:
* KokeScraper http://www.comuni-italiani.it/012/lista.html http://www.comuni-italiani.it/013/lista.html 0
* KokeScraper http://www.comuni-italiani.it/012/lista.html http://www.comuni-italiani.it/013/lista.html 0 -xml
* KokeScraper http://www.comuni-italiani.it/012/lista.html http://www.comuni-italiani.it/013/lista.html 0 -txt