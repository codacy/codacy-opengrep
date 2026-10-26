class Shape { // Noncompliant
public:
    virtual double area() const = 0;
    ~Shape() {}
};

class Animal { // Noncompliant
public:
    virtual void speak();
};

class Base {
public:
    virtual ~Base() {}
    virtual void run();
};

class Interface {
public:
    virtual void call() = 0;
protected:
    ~Interface() {}
};

class Leaf final {
public:
    virtual void call();
};

class Plain {
public:
    void call();
    ~Plain() {}
};

struct Iterator {
    int flags; /* when set, iteration visits a virtual leaf (the value
                  stored in the parent) */
    void *data;
};
