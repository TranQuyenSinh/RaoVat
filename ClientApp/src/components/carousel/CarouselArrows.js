import nextArrowImg from '../../assets/images/arrows/slide-next.svg'
import prevArrowImg from '../../assets/images/arrows/slide-prev.svg'

export const NextArrow = ({ className, style, onClick }) => {
    return (
        <div
            style={{ ...style, backgroundImage: `url(${nextArrowImg})` }}
            className={`slick-carousel-arrow next-arrow ${className}`}
            onClick={onClick}
        />
    )
}

export const PrevArrow = ({ className, style, onClick }) => {
    return (
        <div
            style={{ ...style, backgroundImage: `url(${prevArrowImg})` }}
            className={`${className} slick-carousel-arrow prev-arrow`}
            onClick={onClick}
        />
    )
}
