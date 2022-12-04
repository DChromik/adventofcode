#[cfg(test)]
mod tests {
    use crate::days::day1::compute_part_1;

    #[test]
    fn should_compute_part_1() {
        let result = compute_part_1("src/days/day1/input_small.txt");
        assert_eq!(result[0], 24000);
    }

    #[test]
    fn should_compute_part_2() {
        let result = compute_part_1("src/days/day1/input_small.txt");
        assert_eq!(result[0..3], [24000, 11000, 10000]);
    }
}