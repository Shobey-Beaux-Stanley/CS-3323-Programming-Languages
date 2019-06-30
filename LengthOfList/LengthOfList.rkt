#lang racket
;This is just an exercise to make the length function in the api by hand
(define (myLengthFunction list(lengthOfList 0))
        (if (null? list)
            lengthOfList
            (myLengthFunction (cdr list) (add1 lengthOfList))))
print "Enter a list in parenthesis to output the length of: "
(myLengthFunction (read))