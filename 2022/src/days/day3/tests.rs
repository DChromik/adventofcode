#[cfg(test)]
mod tests {
    use std::path::Path;

    use crate::days::day3;


    #[test]
    fn should_compute_part_1() {
        let path = Path::new("./src/days/day3/input_small.txt");
        let result = day3::resolve_part_1(path);
        assert_eq!(result, 157);
    }

    #[test]
    fn should_compute_part_2() {
        let path = Path::new("./src/days/day3/input_small.txt");
        let result = day3::resolve_part_2(path);
        assert_eq!(result, 70);
    }
}