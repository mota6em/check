package walking.game.player;
import walking.game.util.Direction;

public class MadlyRotatingBuccaneer extends Player{
    private int turnCount;
    public MadlyRotatingBuccaneer(){
        super();
        turnCount = 0;
    }

    public void turn() {
        if (turnCount > 0) {
            switch (direction) {
                case Direction.UP:
                    direction = Direction.LEFT;     
                    break;
            
                case Direction.RIGHT:
                    direction = Direction.UP;
                    break;
            
                case Direction.DOWN:
                    direction = Direction.RIGHT;   
                    break;
            
                case Direction.LEFT:
                    direction = Direction.DOWN;
                    break;
            
            }
        }
        turnCount++;
    }
}
