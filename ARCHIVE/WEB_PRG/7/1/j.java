public class j {
    public static void main(String[] args) {
        int[] numbers = {3, 7, 2, 5, 8};
        int index = firstEvenIndex(numbers);
        if (index != -1) {
            System.out.println("Az első páros szám indexe: " + index);
        } else {
            System.out.println("Nincs páros szám a tömbben.");
        }
    }

    public static int firstEvenIndex(int[] numbers) {
        for (int i = 0; i < numbers.length; i++) {
            if (numbers[i] % 2 == 0) {
                return i; 
            }
        }
        return -1; 
    }
}
