#include  <stdio.h>
#include  <unistd.h>
#include  <stdlib.h>
#include  <sys/types.h>
#include  <linux/ipc.h>
#include  <linux/sem.h>

int semid ;
int ret ;
static struct sembuf decrease = { 0, -1, 0} ;
static struct sembuf increase = { 0, 1, 0 } ;
//-------------------------------------------------------
// create_sem() creates an semaphore and return 1
//-------------------------------------------------------
int create_sem(char *path, char name, int initval) {
  key_t ipc_key ;	
  union semun arg ;
  static ushort start_val[1] = { 0 } ;
  
  ipc_key = ftok(path,name); 
  semid = semget(ipc_key, 1, IPC_CREAT| 0666) ;

  if (semid != -1) {
    // INITIALIZE THE SEMPHORE WITH VALUE 0 
    start_val[0] = initval ;
    arg.array = start_val ;
    ret = semctl(semid, 0, SETALL, arg);
    if (ret == -1) {
      perror("semctl -- initialization failed");
      exit(1);
    }
   }
   return semid ;
}
//--------------------------------------------------------------------------
// register_sem() use a path and a char to locate an existing semaphore and
// return its semphore id
//-------------------------------------------------------------------------- 
int get_sem(char *path, char name) {
  int semid ;
  key_t ipc_key ;

  ipc_key = ftok(path,name);
  semid = semget(ipc_key, 1,0);
  return semid ;
}
//---------------------------------------------------------
// because wait() and signal() are easy to be confused with
// monitor's wait() and signal(), so we use name P and V
//---------------------------------------------------------
void P(int semid) {
    semop(semid, &decrease, 1 );
}
void V(int semid) {
    semop(semid, &increase, 1);
}
//---------------------------------------------------------
// remove_sem removes a semaphore 
//---------------------------------------------------------
void destroy_sem(int semid) {
  if (semctl(semid,0,IPC_RMID,0) == -1) {
    perror("semctl -- remove");
    exit(1);
  }
}
//--------------------------------------------------------
int get_blocked_no(int semid) {
  int waitno ;
  union semun arg ;
  static ushort vals[1] ;
  
  arg.array = vals ;

  // NOW WE WANT TO GET THE NUMBER OF PROCESSES WAITING ON THE SEMAPHORE

  if ((waitno= semctl(semid,0,GETNCNT,arg)) == -1) {
    perror("semctl -- get semaphore GETNCNT");
    exit(1);
  }
  return waitno ;
}
//--------------------------------------------------------
int  get_sem_val(int semid) {

  int semval ;
  union semun arg ;
  static ushort vals[1] ;
  if ((semval=   semctl(semid,0,GETVAL,arg)) == -1) {
    perror("semctl -- get semaphore values");
    exit(1);
  }
  return semval ;
}

      
    
