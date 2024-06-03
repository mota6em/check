package walking.game;
import walking.game.util.Direction;

import static check.CheckThat.*;
import static org.junit.jupiter.api.Assertions.*;

import java.beans.Transient;

import org.junit.jupiter.api.*;
import org.junit.jupiter.api.condition.*;
import org.junit.jupiter.api.extension.*;
import org.junit.jupiter.params.*;
import org.junit.jupiter.params.provider.*;
import check.*;
import walking.game.util.Direction;
public class WalkingBoardTest {
    @ParameterizedTest(name="testSimpleInit(size)")
    @CsvSource(textBlock="""
            3
            10
            0
            21
            """)
    @DisableIfHasBadStructure
    public void testSimpleInit(int size){
        WalkingBoard wb = new WalkingBoard(size);
        for(int i = 0 ; i < size ; i++){
            for(int j = 0; j < size ; j++){
            assertEquals(3,wb.getTile(i, j));
            }
        }
    }

    @ParameterizedTest(name="testCustomInit(x, y, expected)")
    @CsvSource(textBlock="""
            0, 0, 3
            0, 1, 3
            0, 2, 3
            0, 3, 3
            1, 0, 3
            1, 1, 3
            1, 2, 3
            1, 3, 3
            2, 0, 9
            2, 1, 99
            2, 2, 999
            2, 3, 9
            """)
    @DisableIfHasBadStructure 
    public void testCustomInit(int x, int y, int expected){

        // test of 3×4 array
        int[][] mrx = {
            {2,0,1,2},  //  (values that are LESS than 3)
            {1,2,0,1},  //  (values that are LESS than 3)
            {9,99,999,9}, //(values that are MORE than 3)
        };
        WalkingBoard wb = new WalkingBoard(mrx);
        assertEquals(expected, wb.getTile(x, y));

        mrx[2][3] = 2;
        mrx[2][2] = 0;
        mrx[0][0] =22; // change a value in the array to see if it changes in wb's array or not
        assertEquals(expected, wb.getTile(x,y)); // test if it's not equal or not, if it's not equal so erverything is good.

        int[][] newMRX = wb.getTiles();  // Change a value in the array created by .getTiles(), to test whether it will change in the wb's array as well or not
        newMRX[0][0] = 22;
        newMRX[2][2] = 0;  
        newMRX[2][3] = 2;
        assertEquals(expected, wb.getTile(x, y));


        //Tests the isValidPosition() method with different positions.
        // Verifies that the method correctly determines the validity of positions on the WalkingBoard.
        assertEquals(true, wb.isValidPosition(0, 0));
        assertEquals(true, wb.isValidPosition(1, 1));
        assertEquals(true, wb.isValidPosition(2, 0));
        assertEquals(false, wb.isValidPosition(-1, 1));
        assertEquals(false, wb.isValidPosition(3, 3));
        assertEquals(false, wb.isValidPosition(0, -2));

        // Test to verify if the structure of the wb object changes or remains the same when initializing with a new array.
        int[][] newTestMrx = {
            {1, 2}
        };
        wb = new WalkingBoard(newTestMrx);
        assertEquals(1, wb.getTiles().length); // Check if the number of rows in wb matches the new array
        assertEquals(2, wb.getTiles()[0].length); // Check if the number of columns in wb matches the new array

    }

    @Test 
    public void testMoves(){
        int[][] mrx = {
            {  50 ,  50 , 1   },
            {  1  ,  2  , 0   },
            {  9  ,  99 , 999 },
            {  3  ,  0 , 3 },
        };
        WalkingBoard wb = new WalkingBoard(mrx);
        
        /*
         * Tests the movement functionality of the WalkingBoard class.
         * Verifies that the board correctly handles movement in all directions,
         * including boundary conditions and updating cell values.
        */

        Direction dr = Direction.LEFT; 
        assertEquals(0, wb.moveAndSet(dr, 5)); //Out of bounds (will stay in the primary place.)
            int[] expectedPosition = {0, 0};
            assertArrayEquals(expectedPosition, wb.getPosition()); //test of .getPosition() also

        dr = Direction.RIGHT;
        assertEquals(50, wb.moveAndSet(dr, 16)); // →
            expectedPosition = new int[]{0, 1};
            assertArrayEquals(expectedPosition, wb.getPosition());

        
        dr = Direction.DOWN;
        assertEquals(3, wb.moveAndSet(dr, 16)); // ↓
            expectedPosition = new int[]{1, 1};
            assertArrayEquals(expectedPosition, wb.getPosition()); 

        dr = Direction.UP;
        assertEquals(16, wb.moveAndSet(dr, 61)); // ↑  back to up to check whether the value has changed or not
            expectedPosition = new int[]{0, 1};
            assertArrayEquals(expectedPosition, wb.getPosition()); 

        dr = Direction.RIGHT;
        assertEquals(3, wb.moveAndSet(dr, 16));  // →
            expectedPosition = new int[]{0, 2};
            assertArrayEquals(expectedPosition, wb.getPosition()); 

        dr = Direction.RIGHT;
        assertEquals(0, wb.moveAndSet(dr, 16)); // → BUT! Out of bounds
            expectedPosition =new int[] {0, 2};
            assertArrayEquals(expectedPosition, wb.getPosition()); 
        
    } 

}



