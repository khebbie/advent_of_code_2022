open System.Collections.Generic
open System.IO

type Play =
    | Rock = 1
    | Paper = 2
    | Scissors = 3
    

let decryptTheirPlay (input: string):Play = 
    match input with 
        |"A" -> Play.Rock
        |"B" -> Play.Paper
        |"C" -> Play.Scissors
        | _ -> failwith "unknown play"


let decryptMyPlay(input: string):Play = 
    match input with 
        |"X" -> Play.Rock
        |"Y" -> Play.Paper
        |"Z" -> Play.Scissors
        | _ -> failwith "unknown play"

type Game = 
    { TheirPlay: Play
      MyPlay: Play}

// The score for a single round is the score for the shape you selected (1 for Rock, 2 for Paper, and 3 for Scissors) 
// plus the score for the outcome of the round (0 if you lost, 3 if the round was a draw, and 6 if you won).
let completeScore(game: Game) =
    match game with
        | {MyPlay = Play.Rock; TheirPlay = Play.Rock} -> (1 + 3)
        | {MyPlay = Play.Rock; TheirPlay = Play.Paper} -> (1 + 0)
        | {MyPlay = Play.Rock; TheirPlay = Play.Scissors} -> (1 + 6)
        | {MyPlay = Play.Paper; TheirPlay = Play.Rock} -> (2 + 6)
        | {MyPlay = Play.Paper; TheirPlay = Play.Paper} -> (2 + 3)
        | {MyPlay = Play.Paper; TheirPlay = Play.Scissors} -> (2 + 0)
        | {MyPlay = Play.Scissors; TheirPlay = Play.Rock} -> (3 + 0)
        | {MyPlay = Play.Scissors; TheirPlay = Play.Paper} -> (3 + 6)
        | {MyPlay = Play.Scissors; TheirPlay = Play.Scissors} -> (3 + 3)
        | {MyPlay = _; TheirPlay = _} -> failwith "Unknown Game play"



let filePath = "/src/elixir/advent_of_code/day2/input_real.txt"
let fileContents = File.ReadAllText filePath

let lines = fileContents.Split '\n'
let map =
    lines
    |> Array.filter (fun line -> line.Trim().Length > 0)
    |> Array.map (fun line -> decryptTheirPlay( line.[0].ToString()), decryptMyPlay( line.[2].ToString()))
    |> Array.map (fun encoded ->  {TheirPlay = fst(encoded); MyPlay = snd(encoded)})
    |> Array.map(fun game -> completeScore(game))
    |> Array.sum
printfn "%d" map


//printfn "%s" fileContents
