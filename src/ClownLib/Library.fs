namespace ClownLib

module Mastermind =

    type Color =
        | Red
        | Blue
        | Green
        | Pink
        | Yellow
        | Turkis

    let remove (e: Color) (l: Color List) =
        let rec acc e l res =
            match l with
            | x :: xs -> if x = e then res @ xs else acc e xs res
            | [] -> res
        acc e l []

    let diff (answer:Color list) (guess:Color list) : int * int =
        let rightColorRightPosition =
            List.indexed guess
            |> List.filter (fun (i, c) -> answer.[i] = c)
            |> List.map (fun (i, c) -> c)
        let remaining =
            List.fold
                (fun s c -> remove c s)
                answer
                rightColorRightPosition
        let rightColorOnly =
            guess
            |> List.fold (fun (result, remaining) c ->
                if List.contains c remaining
                    then (c :: result, remove c remaining)
                    else (result, remaining))
                ([], remaining)
        (List.length rightColorRightPosition, List.length (fst rightColorOnly))
