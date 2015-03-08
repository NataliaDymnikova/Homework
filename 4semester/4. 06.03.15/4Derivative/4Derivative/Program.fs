type Operation = char
type Number = int
type Variable = char
type Expression = 
    | Constants of Number
    | Variable of Variable
    | LongExpression of Expression * Operation * Expression

/// Convert to string.
let rec expressionToString expression = 
    match expression with
    | Constants cons -> cons.ToString()
    | Variable var -> var.ToString()
    | LongExpression(left, oper, right) -> "(" + (expressionToString left) + oper.ToString() + (expressionToString right) + ")"

let calculateTwoNumbers number1 number2 opertion = 
    match opertion with
    | '+' -> number1 + number2
    | '-' -> number1 - number2
    | '*' -> number1 * number2
    | '/' -> number1 / number2
    | _ -> 0

let rec simplification expression = 
    match expression with
    | Constants _ -> expression
    | Variable _ -> expression
    | LongExpression (left, operation, right) ->
        let leftS = simplification left
        let rightS = simplification right
        
        match leftS with
        | Constants (l) ->
            match rightS with
            | Constants (r) -> Constants (calculateTwoNumbers l r operation)
            | _ -> 
                if (l = 1 && operation = '*') || (l = 0 && (operation = '+' || operation = '-')) then
                    rightS
                elif (l = 0) && (operation = '*' || operation = '/') then
                    Constants(0)
                else
                    LongExpression(leftS, operation, rightS)
        | _ ->
            match rightS with
            | Constants (r) ->
                if (r = 1 && (operation = '*' || operation = '/')) || (r = 0 && (operation = '+' || operation = '-')) then
                    leftS
                elif r = 0 && operation = '*' then
                    Constants(0)
                else
                    LongExpression(leftS, operation, rightS)
            | _ ->  LongExpression(leftS, operation, rightS)


let rec derivative expression = 
    match expression with
    | Constants _ -> Constants 0
    | Variable _ -> Constants 1
    | LongExpression (left, oper, right) ->
        match oper with
        | '+' | '-' -> LongExpression(derivative left, oper, derivative right)
        | '*' -> LongExpression(LongExpression(derivative left, '*', right), '+', LongExpression(left, '*', derivative right))
        | '/' -> LongExpression(LongExpression(LongExpression(derivative left, '*', right), '-', LongExpression(left, '*', derivative right)), '/', LongExpression(left, '*', left))
        | _ -> Constants 0

let expr = LongExpression(LongExpression(Variable 'x', '+', Variable 'x'), '-', LongExpression(Constants 1, '*', Variable 'x'))
printfn "expression"
printfn "%s" (expressionToString expr)
printfn "Simplification"
printfn "%s" (expressionToString (simplification expr))
printfn "Derivative"
printfn "%s" (expressionToString (derivative expr))
printfn "Simplification <- derivative"
printfn "%s" (expressionToString (simplification (derivative expr)))