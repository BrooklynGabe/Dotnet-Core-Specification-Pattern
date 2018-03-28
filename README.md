# Dotnet-Core-Specification-Pattern
General use wrapper for joining specifications / restrictions that test if a condition is satisfied.


## Build Status

 + Release ![Master Branch Status](https://gabe.visualstudio.com/_apis/public/build/definitions/8119b92f-16d5-4ce2-9ade-814b75b0a4cb/9/badge)
 + Pre-Release ![Other Branches' Status](https://gabe.visualstudio.com/_apis/public/build/definitions/8119b92f-16d5-4ce2-9ade-814b75b0a4cb/8/badge)


## Usage

See unit tests for how each `Specification` instance can be combined with logic operators. 

```
// ...

var startingYear = 2018;
var edition = 3;
var publishedOnOrAfter = new Specification<Book>(book => book.PublishingYear >= startingYear);
var specificEdition = new Specification<Book>(book => book.Edition == edition);

// ...

var searchCriteria = publishedOnOrAfter & specificEdition;
var searchResults = Books.Where(searchCriteria).ToArray();

...
```