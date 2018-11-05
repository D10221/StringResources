# ScriptResources

Find Embbeded strings by convention.
Associating a Member Name to a string/s that you dont want to inline  
... because it's too long :)


Usage:
    
    class MyClass { 

        public string MyResouce {get;} = StringResource.ScriptFor<MyClass>("MyResouce");

        public string MyString(){
            return StringResource.ScriptFor<MyClass>("MyString");
        }

        public string X {get;} = StringResource.ScriptFor<MyClass>("MyString");
    }
    
Where /MyClass.MyResouce.sql its an Embedded resource 'aside' MyClass.cs;

# Note
```
myProject.csproj  
    SubDirWorks        
        # if MyClass declares namespace matching location
        MyClass.cs         
        # Will be Found in 'same namespace'
        MyClass.xName.sql  
        # Expected fullName OK => 'SubdirWorks.MyClass.xName.sql'
    SubDirDoesntWork
        # Not Found! , different namespace than MyClass
        MyClass.xName2.sql 
    SubDir2
        # this time MyClass's namespace doesn't reflect location
        MyClass.cs 
        # Won't be found
        MyClass.xName2.sql   
```

### Why Default to Sql?

- Becasue is the intended use case.  

### Why not inline strings?

 - Because you loose syntax highlighting, 
 - Auto formatting, 
 - Is not tidy 
 - Mostly if its more than 50 chars long or more than 3 lines of code.
 - Because you can copy the file path and open it on your favorite sql editor ? 




