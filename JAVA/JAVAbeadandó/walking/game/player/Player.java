package walking.game.player;

import walking.game.util.Direction;

public class Player {
    private int score;
    public int getScore(){
        return score;
    }
    protected walking.game.util.Direction direction = Direction.UP;
    public Direction getDirection(){
        return direction;
    }
    public Player(){
        score = 0;
    }
    public void addToScore(int score){
        this.score += score;
    }
    public void turn(){
        switch (direction) {
            case Direction.UP:
                direction = Direction.RIGHT;        
                break;
        
            case Direction.RIGHT:
                direction = Direction.DOWN;
                break;
        
            case Direction.DOWN:
                direction = Direction.LEFT;
                break;
        
            case Direction.LEFT:
                direction = Direction.UP;
                break;
        
        }
    }
}
