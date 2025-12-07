# Day 2 solutions
module Day2
  def self.part1(path)
    result = 0
    File.foreach(path) do |line|
      parts = line.split(',')

      parts.each do |part|
        from, to = part.scan(/\d+|\d+/)

        next if from.nil? || to.nil?

        (from..to).each do |i|
          result += i.to_i if i.match?(/^(\d+)\1$/)
        end
      end
    end
    result
  end

  def self.part2(path)
    result = 0
    File.foreach(path) do |line|
      parts = line.split(',')

      parts.each do |part|
        from, to = part.scan(/\d+|\d+/)

        next if from.nil? || to.nil?

        (from..to).each do |i|
          result += i.to_i if i.match?(/^(\d+)\1+$/)
        end
      end
    end
    result
  end
end
