from random import *
from tkinter import *
import time

########################### INIT TK #################################
root = Tk()
frame_main = Frame(root)
frame_main.pack()
root.geometry('1000x1000')
canvas = Canvas(frame_main, width=1000, height=1000)
canvas.pack()
canvas.update()
#####################################################################


############################# (RE)-SET BOARD ########################
board = []
for i in range(10):
    board.append([0]*10)
board [4] [4] = 1
    
def reset ():
    board = []
    for i in range(10):
        board.append([0]*10)
    board [4] [4] = 1
#####################################################################
    

############################ PRINT THE ROOM #########################
def drawCell (x, y, color):
    canvas.create_rectangle(x, y, x+50, y+50, fill = 'white')   
    canvas.create_rectangle(x+2, y+2, x+48, y+48, fill = color)
#####################################################################
    
    
############################# PRINT THE MAP #########################
def drawBoard (board):
    y = 0
    rows = len(board)
    cols = len(board[0])
    for i in range(rows):
        x = 0
        y += 50
        for j in range(cols):
            x += 50
            if board[i][j] == 2:
                drawCell(x, y, 'red')
            elif board[i][j] == 1:
                drawCell(x, y, 'black')
            else:
                drawCell(x, y, 'white')
    canvas.update()
#####################################################################
    
    
############################# RANDOM PART ###########################
def isGen (x,y, nb_salle):
    seed()
    is_gen = randint(0,1)
    if is_gen == 1 and board [x] [y] == 0 and countNeighbours(x,y) and nb_salle < 10:
        board [x] [y] = 1
        nb_salle += 1
        res = True
    else:
        res = False
    return res
#####################################################################


############################ GENERATION CONDITIONS ##################
def countNeighbours (x,y):
    nb_neighbours = 0
    for (i,j) in ((x-1,y), (x,y+1), (x+1,y), (x,y-1)):
        if board [i] [j] == 1:
            nb_neighbours +=1
    if nb_neighbours != 1:
        board [x] [y] = 2
        res = False
    else :
        res = True
    return res
#####################################################################


######################### RECURSIVITE ###############################
def nextGen (board, x, y, n):
    nb_salle = n + 1
    if nb_salle < 10:
        for (i,j) in ((x-1,y), (x,y+1), (x+1,y), (x,y-1)):
            if i >= 1 and i < 9 and j >=1 and j < 9:
                if isGen(i,j,n):
                    nextGen(board, i, j, nb_salle+1)
        drawBoard(board)
#####################################################################

nextGen(board, 4, 4, 1)
                  
                
    
