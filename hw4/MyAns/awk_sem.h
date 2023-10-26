int create_sem(char *path, char name, int initval) ;
int get_sem(char *path, char name) ;
void P(int semid);
void V(int semid);
void destroy_sem(int semid);
int get_blocked_no(int semid);
int  get_sem_val(int semid) ;
