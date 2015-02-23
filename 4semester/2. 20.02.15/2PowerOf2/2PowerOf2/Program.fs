let number = 5

/// Return list
let rec powerOf2 count previousPower list = 
    if count = 1
        then List.append list [previousPower]
    else
        powerOf2 (count - 1) (previousPower * 2) (List.append list [previousPower])

/// result^number
let rec power number result = 
    if number >= 1
        then power (number - 1) (result * 2)
    else
        result

List.iter (fun x -> printf "%d " x) (powerOf2 5 (power number 1) [])