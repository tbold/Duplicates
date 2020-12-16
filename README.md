# Duplicates

ASP .NET MVC web application to find duplicate records in a database using phonetic matching. This is especially useful for when there has been a typo in a person's name or address and created a duplicate record, eg. Michael Smith vs Michel Smith vs Mickel Smith might be same record.
![alt text][home]

### How to run
1. Clone the repository

2. Open solution in Visual Studio 2017 or 2019

3. Build and run

### How to use
1. Upload a csv file. There is an example file in the repository `MOCK_DATA.csv`

2. Select a unique identifier, it signifies how each records are distinguished from one another

3. Select a search option, only `manual search` is supported at the moment.

4. Review results in the browser of returned potential matches.

### Search preview
<details><summary><b>Expand</b></summary>

![alt text][preview]
</details>

### Technologies
* ASP.NET Core 3
* Entity Framework Core 3
* [Phonix]'s Double Metaphone algorithm

[Phonix]: https://github.com/eldersantos/phonix
[preview]: https://github.com/tbold/Duplicates/blob/master/images/search_preview.gif
[home]: https://github.com/tbold/Duplicates/blob/master/images/home_page.png
