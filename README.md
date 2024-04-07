# CANDIDATE CODING ASSIGNMENT

## Coding assignment

Write a C# application with the associated unit tests that will be able to take multiple text filters and apply them on any given string. This should take no more than 2 hours.

The application should:
[x] Read from a txt file
[x] Create and apply the following 3 filters:
[x] Filter1 – filter out all the words that contains a vowel in the middle of the word – the centre 1 or 2 letters ("clean" middle is ‘e’, "what" middle is ‘ha’, "currently" middle is ‘e’ and should be filtered, "the", "rather" should not be)
[x] Filter2 – filter out words that have length less than 3
[x] Filter3 – filter out words that contains the letter ‘t’
[x] After all filters have completed display the resulted text in the console;

## Assumptions
* Words are separated by either whitespace ' ', tab '\t', or newline '\n'
* Words can be alphanumeric or special characters for e.g. apple, 124, $$$, are all considered invidual words
* However, special characters are not considered when performing vowel check or length check
* Words with special characters at start and end that are filtered return the special characters for .e.g. 'boy' -> '', hell! -> !
