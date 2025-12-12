# frozen_string_literal: true

# Day 2 solutions
module Day2
  def self.part1(path)
    File.foreach(path).sum do |line|
      count_invalid_ids(line, /^(\d+)\1$/)
    end
  end

  def self.part2(path)
    File.foreach(path).sum do |line|
      count_invalid_ids(line, /^(\d+)\1+$/)
    end
  end

  # Finds and counts all invalid ID values for line
  def self.count_invalid_ids(line, invalid_id_pattern)
    line.strip.split(",").sum do |id_range|
      from, to = id_range.strip.split("-")

      next 0 unless from && to

      (from.to_i..to.to_i).select { |i| i.to_s.match?(invalid_id_pattern) }.sum
    end
  end
end
