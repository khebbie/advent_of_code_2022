(ns day3.core
  (:require [clojure.string :as str])
  (:require [clojure.set :as set])
  (:require [clojure.java.io :as io])
  (:gen-class))


(defn read-file [filename]
  (with-open [rdr (io/reader filename)]
    (slurp rdr)))

(defn split-into-compartments [input]
  (->> input
      (split-at (/ (count input)  2))
      (map set)
      (apply clojure.set/intersection)
      ))

(defn letter-to-number [letter]
  (def ch (char (first letter)))
 (cond
   (Character/isLowerCase ch) (- (int ch) 96)
   (Character/isUpperCase ch) (+ 26 (- (int ch) 64))
   :else 0))

(defn -main
  "solve day 3 of advent of code 2022"
  [& args]
(->> "/src/elixir/advent_of_code/day3/day3/input_real.txt"
     read-file
     str/split-lines
     (map split-into-compartments)
     (map letter-to-number)
     (reduce +)
(println)
     )
  (println "done!"))







