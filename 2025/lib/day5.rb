# frozen_string_literal: true

# Day 5 solutions
module Day5
  def self.part1(path)
    ranges, ids = File.read(path).split("\n\n")

    fresh_id_ranges = ranges.each_line.map { line_to_range(it) }

    ids.each_line.map(&:to_i).count do |id|
      fresh_id_ranges.any? { it.include? id }
    end
  end

  def self.part2(path)
    ranges, _ = File.read(path).split("\n\n")

    sorted_ranges = ranges.each_line
      .map { line_to_range(it) }
      .sort_by { it.min }

    merged_ranges = sorted_ranges.each_with_object([]) do |range, merged|
      if merged.empty? || merged.last.max < range.min - 1
      else
        last_range = merged.pop
        merged << (last_range.min..[last_range.max, range.max].max)
      end
    end

    merged_ranges.sum { it.size }
  end

  def self.line_to_range(line)
    line.split("-").map(&:to_i).then { (_1.._2) }
  end
end
