/// Return all prime numbers
let seqAllPrimes = 
    let rec seqPrime currentNumber = seq {
        let rec isPrime number currentNumber = 
            if number * number <= currentNumber then
                if currentNumber % number = 0 then
                    false
                else
                    isPrime (number + 1) currentNumber
            else
                true

        if (isPrime 2 currentNumber) then
            yield currentNumber
        yield! seqPrime (currentNumber + 1)
    }
    seqPrime 2

let somePrimes = Seq.truncate 100 seqAllPrimes
Seq.iter (fun x -> printf "%d " x) somePrimes