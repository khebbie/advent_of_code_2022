import scala.io.Source

object Main extends App {
  var count = 0
  val filename = "/src/elixir/advent_of_code/day4/day4/input_real.txt"
  for (line <- Source.fromFile(filename).getLines) {
      val Array(range1, range2) =line
      .split(",")
      .map((range: String) => {
        val Array(first, second) = range.split("-")
        Range.inclusive(first.toInt,second.toInt)
      })
      if(range1.containsSlice(range2) || range2.containsSlice(range1)){
        println("found")
        count = count + 1
      }


  }

    println(count)
}

