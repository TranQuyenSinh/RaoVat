import React from 'react'

import { Tab, Tabs, TabList, TabPanel } from 'react-tabs'
import 'react-tabs/style/react-tabs.css'
import Section from '../../../components/customer/Section/Section'

import './ManageAd.scss'
const ManageAd = () => {
    return (
        <Section className='manage-ad-container'>
            <div className='user-info'></div>
            <Tabs>
                <TabList>
                    <Tab>Đang hiển thị (1)</Tab>
                    <Tab>Hết hạn (0)</Tab>
                    <Tab>Bị từ chối (0)</Tab>
                    <Tab>Chờ duyệt (0)</Tab>
                    <Tab>Đã ẩn (0)</Tab>
                </TabList>

                <TabPanel>
                    <h2>Danh sách tin Đang hiển thị</h2>
                </TabPanel>
                <TabPanel>
                    <h2>Danh sách tin Hết hạn</h2>
                </TabPanel>
                <TabPanel>
                    <h2>Danh sách tin Bị từ chối</h2>
                </TabPanel>
                <TabPanel>
                    <h2>Danh sách tin Chờ duyệt</h2>
                </TabPanel>
                <TabPanel>
                    <h2>Danh sách tin Đã ẩn</h2>
                </TabPanel>
            </Tabs>
        </Section>
    )
}

export default ManageAd
