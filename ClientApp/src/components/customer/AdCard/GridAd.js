import React from 'react'
import './GridAd.scss'
import AdCard from './AdCard'
import AdNotFound from '../../notfound/AdNotFound/AdNotFound'
import { motion } from 'framer-motion'

const fadeUpAnimation = {
    initial: {
        opacity: 0,
        y: 100,
    },
    animate: index => ({
        opacity: 1,
        y: 0,
        transition: {
            delay: 0.05 * index,
        },
    }),
}
const GridAd = ({ data }) => {
    return (
        <>
            <div className='gridAd'>
                {data && data.length > 0 ? (
                    data.map((item, index) => (
                        <motion.div
                            variants={fadeUpAnimation}
                            initial='initial'
                            whileInView='animate'
                            viewport={{ once: true }}
                            custom={index}
                            key={item.id}
                            style={{ width: '20%' }}>
                            <AdCard key={item.id} ad={item} />
                        </motion.div>
                    ))
                ) : (
                    <AdNotFound />
                )}
            </div>
        </>
    )
}

export default GridAd
