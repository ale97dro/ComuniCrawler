# Koke

Koke is a web scraper based on HtmlAgilityPack.

At this moment, this scraper can find informations about city in page like [this](http://www.comuni-italiani.it/012/lista.html): at this moment Koke extract only the list of cities.

# Command line

Koke work with command line: you can pass how many urls you want and then Koke print them on your console.

If you want to save the results, you can specify as last parameter '-txt' or '-xml' to specify the file type.

Here some examples of Koke execution:
	* KokeScraper http://www.comuni-italiani.it/012/lista.html http://www.comuni-italiani.it/013/lista.html
	* KokeScraper http://www.comuni-italiani.it/012/lista.html http://www.comuni-italiani.it/013/lista.html -xml
	* KokeScraper http://www.comuni-italiani.it/012/lista.html http://www.comuni-italiani.it/013/lista.html -txt