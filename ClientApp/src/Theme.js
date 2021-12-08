import React, { useEffect, createContext, useState } from "react";

const ThemeContext = createContext();

const getTheme = () => {
    const theme = localStorage.getItem("theme");
    if (!theme) {
        // Default theme is taken as dark-theme
        localStorage.setItem("theme", "dark-theme");
        document.documentElement.classList.add("dark-theme")
        return "dark-theme";
    } else {
        document.documentElement.classList.add(theme)
        return theme;
    }
};

const ThemeProvider = ({ children }) => {
    const [theme, setTheme] = useState(getTheme);

    function toggleTheme() {
        if (theme === "dark-theme") {
            setTheme("light-theme");
        } else {
            setTheme("dark-theme");
        }
    };

    useEffect(() => {
        const refreshTheme = () => {
            localStorage.setItem("theme", theme);
        };

        if (theme === "light-theme") {
            document.documentElement.classList.replace("dark-theme", "light-theme")
        } else {
            document.documentElement.classList.replace("light-theme", "dark-theme")
        }

        refreshTheme();
    }, [theme]);

    return (
        <ThemeContext.Provider
            value={{
                theme,
                setTheme,
                toggleTheme,
            }}
        >
            {children}
        </ThemeContext.Provider>
    );
};

export { ThemeContext, ThemeProvider };