export const fadeUp = {
    initial: {
        y: 100,
        opacity: 0,
    },
    animate: {
        y: 0,
        opacity: 1,
        transition: { type: 'tween', duration: 0.7 },
    },
}

export const fadeDown = {
    initial: {
        y: -100,
        opacity: 0,
    },
    animate: {
        y: 0,
        opacity: 1,
        transition: { type: 'tween', duration: 0.7 },
    },
}

export const fadeRight = {
    initial: {
        x: -100,
        opacity: 0,
    },
    animate: {
        x: 0,
        opacity: 1,
        transition: { type: 'tween', duration: 0.7 },
    },
}

export const fadeLeft = {
    initial: {
        x: 200,
        opacity: 0,
    },
    animate: {
        x: 0,
        opacity: 1,
        transition: { type: 'tween', duration: 0.7 },
    },
}

export const fadeIn = {
    initial: {
        opacity: 0,
    },
    animate: {
        opacity: 1,
        transition: { duration: 0.3 },
    },
}
