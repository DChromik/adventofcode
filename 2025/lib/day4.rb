# frozen_string_literal: true

# Day 4 solutions
module Day4
  def self.part1(path)
    grid = Grid.new
    File.foreach(path) do |line|
      grid.add_line(line)
    end
    grid.count_accessible_rolls
  end

  def self.part2(path)
    total = 0
    grid = Grid.new
    File.foreach(path) do |line|
      grid.add_line(line)
    end

    while (removed_count = grid.count_accessible_rolls) > 0
      total += removed_count
    end

    total
  end

  class Grid
    def initialize
      @rows = []
    end

    def width
      @rows[0].size
    end

    def height
      @rows.size
    end

    def add_line(line)
      @rows << line.strip.chars
    end

    def count_accessible_rolls
      removable_coords = []
      @rows.each_with_index do |row, y|
        row.each_with_index do |col, x|
          if get_cell(x, y) === "."
            0
          else
            can_remove = count_neighbors(x, y, "@") < 4

            if can_remove
              removable_coords << [x, y]
            end
          end
        end
      end

      removable_coords.each do |x, y|
        remove_paper(x, y)
      end

      removable_coords.size
    end

    def get_cell(x, y)
      if (y < 0) | (x < 0)
        return nil
      end
      row = @rows[y]
      if row.nil?
        nil
      else
        row[x]
      end
    end

    def remove_paper(x, y)
      @rows[y][x] = "."
    end

    def count_neighbors(x, y, type)
      count = 0
      count += (get_cell(x, y + 1) == type) ? 1 : 0
      count += (get_cell(x, y - 1) == type) ? 1 : 0
      count += (get_cell(x + 1, y) == type) ? 1 : 0
      count += (get_cell(x - 1, y) == type) ? 1 : 0
      count += (get_cell(x + 1, y + 1) == type) ? 1 : 0
      count += (get_cell(x + 1, y - 1) == type) ? 1 : 0
      count += (get_cell(x - 1, y + 1) == type) ? 1 : 0
      count += (get_cell(x - 1, y - 1) == type) ? 1 : 0
      count
    end

    def log
      @rows.each { |row| puts row.join }
      puts width
      puts height
    end
  end
end
