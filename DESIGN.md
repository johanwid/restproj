design of project

- user inputs ticker symbol
- symbol is run through alpha vantage to find company name and stock info
- company name and symbol are searched for on twitter
  - sentiment of company's future is analyzed (nlp api??)
- company financials are searched for (google??)


ideas

- store historical sentiment of a specific user (i.e. bull/bear)


structure/classes

/inp
- class?: takes in user input of ticker symbol
/api
/api/handler
- interface: api handler: takes in url, key
  - class: twitter api handler: for either a sym/name or entire market
    - search
    - filter
  - class: alpha vantage handler
/api/myapi
- interface: for my api (WIP)
/engine
/engine/sentiment
- interface: 
/engine/finance
- interface: security calculator: takes in stock info/options info
  - class: stock calculator
  - class: options calculator: greeks
/data
/data/company
- class: company: company data?
