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

public class WalkingBoardWithPlayersTest {
    @Test 
    public void walk1(){
        int[][] matrix = 
        {
            {1,22,12},
            {2,32,12}
        };
        WalkingBoardWithPlayers wbBoardWithPlayers  = new WalkingBoardWithPlayers(matrix, 2);
        int[] steps = {1,2,1,1,1,1};
        int[] playScores = wbBoardWithPlayers.walk(steps);
        assertEquals(3,playScores[0]);
        assertEquals(25,playScores[1]);
    }
    @Test 
    public void walk2(){
        int[][] matrix = 
        {
            {11,2,2},
            {3,33,2},
            {33,1,2}
        };
        WalkingBoardWithPlayers wbBoardWithPlayers  = new WalkingBoardWithPlayers(matrix, 2);
        int[] steps = {5,2,5,2,5,2};
        int[] playScores = wbBoardWithPlayers.walk(steps);
        assertEquals(44,playScores[0]);
        assertEquals(6,playScores[1]);
    }
}