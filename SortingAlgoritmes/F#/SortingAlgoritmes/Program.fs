// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open System.Collections.Generic

// in-place swap
let swap i j (arr : 'a []) =
    let tmp = arr.[i]
    arr.[i] <- arr.[j]
    arr.[j] <- tmp

// bubbleSort 
let bubbleSort data =
    // recursive loop function
    let rec loop (data : 'a []) =
        let mutable swaps = 0 // the amount of numbers swapt 
        for i = 0 to data.Length - 2 do  // loop though the data with exception of the last number 
            if data.[i] > data.[i+1] then 
                swap i (i+1) data // swap the numbers 
                swaps <- swaps + 1

        if swaps > 0 then loop data else data // if there are numbers swaped do go through the list 
        
    // loop through all the data 
    loop data

let rec mergeSort (data : 'a []) =
    // find the middle and split the array 
    let split (data : _ array) =
        let n = data.Length
        data.[0..n/2-1], data.[n/2..n-1]
        
    // merge the 2 list 
    let rec merge (left : 'a array) (right : 'a array) =
        let n = left.Length + right.Length // get total length 
        let result = Array.zeroCreate<'a> n // create an result array with the length of n 
        let mutable i, j = 0,0 // create 2 dummy variables 
        for k = 0 to n-1 do // loop though the lists  and copy the data in the result array
            if i>=left.Length then result.[k] <- right.[j]; j <- j+1 
            elif j>= right.Length then result.[k] <- left.[i]; i <- i + 1
            elif left.[i] < right.[j] then result.[k] <- left.[i]; i <- i + 1 
            else result.[k] <- right.[j]; j <- j + 1
        
        result
        
    match data with
    | [||] | [| _ |] -> data
    | _ -> let (left_data, right_data) = split data // split the array 
           merge (mergeSort left_data) (mergeSort right_data) // merge the 2 arrays
           
let selectionSort (arr : 'a []) =
    // loop through the array 
    let rec loop n (arr: 'a []) =
        if n>= arr.Length - 1 then arr // if the array length is smaller then n return the total array 
        else
            let mutable x, mini = arr.[n], n
            for i = n+1 to arr.Length - 1 do
                if arr.[i] < x then
                    x <- arr.[i]
                    mini <- i
            if n <> mini then swap n (mini) arr // als n is groter of gelijk is draai de 2 getallen om 
            loop (n+1) arr
    loop 0 arr
           
 
[<EntryPoint>]
let main argv =
    let data = [|3;5;2;1;303;4;2;12;4;5;3;121;|]
    let data1 = [|3;5;2;1;303;4;2;12;4;5;3;121;|]
    let data2 = [|3;5;2;1;303;4;2;12;4;5;3;121;|]
    
    let bubble = bubbleSort data
    let mergesort = mergeSort data1
    let selection = selectionSort data2
    printf "bubble sort: %A \n" bubble
    printf "mergesort: %A \n" mergesort
    printf"selectionSort %A \n" selection
    0