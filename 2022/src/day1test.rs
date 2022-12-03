#[cfg(test)]
mod tests {
    use crate::day1;

    #[test]
    fn should_compute_small_file() {
        let result = day1::compute_day_1("src/input_small.txt");
        assert_eq!(result, 24000);
    }
}